using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Tree.Context;
using Tree.Models;

namespace Tree.Pages
{
    public class UpdateModel : PageModel
    {
        private readonly string FILES_PATH = "Content/Files";
        private readonly int MIN_NUM = 13;
        private readonly IWebHostEnvironment _environment;
        private TreeContext _treeContext;

        public UpdateModel(IWebHostEnvironment environment, TreeContext context)
        {
            _environment = environment;
            _treeContext = context;
        }
        [BindProperty]
        public IFormFile File { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync()
        {
            try
            {
                string fileName = File.FileName;
                //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName.FileName);
                var filePath = Path.Combine(_environment.ContentRootPath, FILES_PATH, fileName);
                var directory = FILES_PATH;
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                {
                    await File.CopyToAsync(fileStream);
                }
                var data = System.IO.File.ReadAllText(filePath);
                List<Class1> input = new();
                if (data != null)
                    input = JsonConvert.DeserializeObject<List<Class1>>(data);
                foreach (var item in input)
                {
                    Models.Attribute  N = new();
                    Models.Attribute M = new();
                    //if(double.Parse(item.n.properties.number)<13 || double.Parse(item.m.properties.number) < 13)
                    //    continue;
                    if (double.Parse(item.n.properties.number!= null? item.n.properties.number : "0") >= MIN_NUM)
                    {
                        int isGood = int.Parse(item.n.properties.number[(item.n.properties.number.LastIndexOf('.') + 1)..]);
                        int code = int.Parse(item.n.properties.number[..(item.n.properties.number.LastIndexOf('.'))]);
                        var check = _treeContext.Attributes.Where(a => a.Code == code && a.IsGood == (isGood == 1 ? true : false)).FirstOrDefault();
                        if (check != null)
                        {
                            N = check;
                        }
                        else if(code != 0 && isGood != 0 )
                        {
                            N = new()
                            {
                                Title = item.n.labels[0],
                                Code = code,
                                IsGood = isGood == 1 ? true : false,
                            };
                            _treeContext.Attributes.Add(N);
                            _treeContext.SaveChanges();
                        }
                    }
                    if (double.Parse(item.m.properties.number != null ? item.m.properties.number : "0") >= MIN_NUM)
                    {
                        int isGood = int.Parse(item.m.properties.number[(item.m.properties.number.LastIndexOf('.') + 1)..]);
                        int code = int.Parse(item.m.properties.number[..(item.m.properties.number.LastIndexOf('.'))]);
                        var check = _treeContext.Attributes.Where(a => a.Code == code && a.IsGood== (isGood==1?true:false)).FirstOrDefault();
                        if (check != null)
                        {
                            M = check;
                        }
                        else if(code != 0 && isGood != 0 )
                        {
                            M = new()
                            {
                                Title = item.m.labels[0],
                                Code = code,
                                IsGood = isGood == 1 ? true : false,
                            };
                            _treeContext.Attributes.Add(M);
                            _treeContext.SaveChanges() ;
                        }
                    }
                    if (N.Id != 0 && M.Id != 0)
                    {
                        if (!_treeContext.RelAttributes.Any(r => r.FkAttributeId == M.Id && r.FkAttributeParentId == N.Id))
                        {
                            RelAttribute rel = new()
                            {
                                FkAttributeId = M.Id,
                                FkAttributeParentId = N.Id,
                            };
                            _treeContext.RelAttributes.Add(rel);
                            _treeContext.SaveChanges();
                        }
                    }
                    if (N.Id == 0 && M.Id != 0)
                    {
                        if (!_treeContext.RelAttributes.Any(r => r.FkAttributeId == M.Id ))
                        {
                            RelAttribute rel = new()
                            {
                                FkAttributeId = M.Id,
                                FkAttributeParentId = null,
                            };
                            _treeContext.RelAttributes.Add(rel);
                            _treeContext.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
