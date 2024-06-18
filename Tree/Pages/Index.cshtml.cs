using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Tree.Context;
using Tree.Models.Dto;

namespace Tree.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMapper _mapper;
        private TreeContext _treeContext;
        //public string TreeViewJSON;
        public List<TreeNode> TreeNodes;
        public AttributeDto Attribute;
        public List<AttributeDto> AllAttributes = new();

        public IndexModel(ILogger<IndexModel> logger, TreeContext context, IMapper mapper)
        {
            _logger = logger;
            _treeContext = context;
            _mapper = mapper;
        }

        public void OnGet()
        {
            var data = _treeContext.Attributes.OrderBy(a=>a.Code).ToList();
            foreach (var attribute in data)
            {
                attribute.Title = attribute.Title+ " " + attribute.Code;
                AllAttributes.Add(_mapper.Map<AttributeDto>(attribute));
            }
        }

        public IActionResult OnPostSubmit(string selectedItems)
        {
            if (selectedItems.IsNullOrEmpty())
                return RedirectToAction("Index");
            List<TreeNode> items = JsonConvert.DeserializeObject<List<TreeNode>>(selectedItems);
            return RedirectToAction("Index");
        }

        public IActionResult OnGetTree(int id)
        {
            var node = _treeContext.Attributes.Where(a => a.Id == id).FirstOrDefault();
            if (node != null)
            {

                List<Root> rootIds =
                [
                    new()
                    {
                        NodeId = node.Id,
                        Level = 0
                    },
                ];
                var result = FindTreeNodes(node, rootIds);
                TreeNodes = new();
                if (result.Any())
                    TreeNodes.AddRange(result);
            }
            return new JsonResult(TreeNodes);

        }

        private List<TreeNode> FindTreeNodes(Models.Attribute node, List<Root> rootIds)
        {
            List<TreeNode> result = new();
            while (true)
            {
                var list = _treeContext.RelAttributes.Include(r => r.Attribute).Include(r => r.AttributeParent)
                    .Where(r => r.FkAttributeParentId == node.Id && r.Attribute.IsGood==node.IsGood).Select(r => r.Attribute).ToList();
                List<TreeNode> children = new();
                if (list.Any())
                {
                    int lastLevel = rootIds.OrderByDescending(r => r.Level).FirstOrDefault().Level;
                    //foreach (var child in list)
                    //    rootIds.Add(new() { NodeId = child.Id, Level = lastLevel + 1 });
                    foreach (var child in list)
                    {
                        rootIds.Add(new() { NodeId = child.Id, Level = lastLevel + 1 });
                        if (!rootIds.Any(r => r.NodeId == child.Id && r.Level <= lastLevel))
                        {
                            //rootIds.Add(child.Id);
                            children.AddRange(FindTreeNodes(child, rootIds));
                        }
                        else
                        {
                            Random rng = new Random();

                            int rand1 = rng.Next(1000000,10000000); // number between 0 and 99

                            children.Add(new()
                            {
                                id = rand1,
                                text = child.Title,
                            });
                            continue;
                        }
                    }
                    result.Add(new()
                    {
                        id = node.Id,
                        text = node.Title,
                        children = children
                    });
                    return result;
                }
                else
                {
                    result.Add(new()
                    {
                        id = node.Id,
                        text = node.Title,
                    });
                    return result;
                }
            }
        }
    }
}
