// See https://aka.ms/new-console-template for more information

using GitHubDesktopSinicizationTool;

string postmanPath = @"C:\Users\Administrator\AppData\Local\GitHubDesktop\app-2.9.4";
Console.WriteLine("Postman路径为：" + postmanPath);

Console.WriteLine("检查 Replace Path.ini文件中...");
if (!File.Exists("Replace Path.ini"))
{
    Console.WriteLine("Replace Path.ini文件缺少！");
    return;
}
string[] replacePaths = File.ReadAllLines("Replace Path.ini");
Console.WriteLine("Replace Path.ini文件已加载");

Console.WriteLine("检查翻译文件 英汉对照.ini 中...");
if (!File.Exists("英汉对照.ini"))
{
    Console.WriteLine("英汉对照.ini！");
    return;
}
var translation = new IniCollection("英汉对照.ini");
Console.WriteLine("翻译脚本已加载");
//备份文件
Backup();
Console.WriteLine("已备份");

Console.WriteLine("开始汉化");
Localization();
Console.WriteLine("汉化完成");

Console.ReadKey();

// 备份文件
void Backup()
{
    //调取ini文件
    foreach (string replacePath in replacePaths)
    {
        File.Copy(postmanPath + replacePath, postmanPath + replacePath + ".bak", true);
        Console.WriteLine("文件" + replacePath + "备份完成");
    }
}


// 汉化
void Localization()
{
    //调取ini文件
    CharacterReplacement characterReplacement = new CharacterReplacement();
    foreach (string replacePath in replacePaths)
    {
        characterReplacement.CharacterReplace(translation["data"], postmanPath + replacePath);
        Console.WriteLine("文件" + replacePath + "汉化完成");
    }
}
