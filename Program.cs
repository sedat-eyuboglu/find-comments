var lineList = new List<string> {
    "/*Test program */", 
    "int main()", 
    "{ ", 
    "  // variable declaration ", 
    "int a, b, c;", 
    "/* This is a test", 
    "   multiline  ", 
    "   comment for ", 
    "   testing */", 
    "a = b + c;", 
    "}"
};

var lineList2 = new List<string> {
    "a/*comment", 
    "line", 
    "more_comment*/b"
};

string ClearComment(string txt)
{
    var startComment = txt.IndexOf("/*");
    if(startComment != -1)
    {
        var endComment = txt.IndexOf("*/", (startComment+2));
        if(endComment != -1)
        {
            var cnt = (endComment + 2) - startComment;
            txt = txt.Remove(startComment, cnt);
            txt = ClearComment(txt);
        }
    }
    return txt;
}

string ClearComment2(string txt)
{
    var startComment = txt.IndexOf("//");
    if(startComment != -1)
    {
        var endComment = txt.IndexOf("@", (startComment+2));
        if(endComment != -1)
        {
            var cnt = endComment - startComment;
            txt = txt.Remove(startComment, cnt);
        }
        else
        {
            txt = txt.Remove(startComment);
        }
        txt = ClearComment2(txt);
    }
    return txt;
}

var text = string.Join("@", lineList);
var result = ClearComment2(ClearComment(text));
var newLines = result.Split("@").Where(e => e != string.Empty).ToArray();
Console.WriteLine(result.Replace("@", " "));

var text2 = string.Join("@", lineList2);
var result2 = ClearComment2(ClearComment(text2));
var newLines2 = result2.Split("@").Where(e => e != string.Empty).ToArray();
Console.WriteLine(result2.Trim());