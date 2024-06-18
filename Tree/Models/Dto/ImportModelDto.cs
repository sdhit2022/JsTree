
public class Rootobject
{
    public List<Class1> inputList { get; set; }
}

public class Class1
{
    public N n { get; set; }
    public R r { get; set; }
    public M m { get; set; }
}

public class N
{
    public int identity { get; set; }
    public string[] labels { get; set; }
    public Properties properties { get; set; }
    public string elementId { get; set; }
}

public class Properties
{
    public string Relationship { get; set; }
    public string number { get; set; }
    public string meaning { get; set; }
    public string central_indicator { get; set; }
    public string excellence_index { get; set; }
    public string examples { get; set; }
    public string name { get; set; }
    public string reason { get; set; }
    public string opposite { get; set; }
}

public class R
{
    public int identity { get; set; }
    public int start { get; set; }
    public int end { get; set; }
    public string type { get; set; }
    public Properties1 properties { get; set; }
    public string elementId { get; set; }
    public string startNodeElementId { get; set; }
    public string endNodeElementId { get; set; }
}

public class Properties1
{
    public string Title { get; set; }
    public string comment { get; set; }
    public string Reason { get; set; }
}

public class M
{
    public int identity { get; set; }
    public string[] labels { get; set; }
    public Properties2 properties { get; set; }
    public string elementId { get; set; }
}

public class Properties2
{
    public string number { get; set; }
    public string meaning { get; set; }
    public string central_indicator { get; set; }
    public string excellence_index { get; set; }
    public string Relationship { get; set; }
    public string examples { get; set; }
    public string reason { get; set; }
    public string name { get; set; }
    public string opposite { get; set; }
}
namespace Tree.Models.Dto
{
    public class ImportModelDto
    {
    }
}
