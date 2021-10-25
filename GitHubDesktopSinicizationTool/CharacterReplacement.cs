using System.Text;

namespace GitHubDesktopSinicizationTool
{
    public class CharacterReplacement
    {
        public void CharacterReplace(Dictionary<string, string> dic, string filePath)
        {
            //读取要被替换的文件
            using StreamReader streamReader = new StreamReader(filePath, Encoding.UTF8);
            string s = streamReader.ReadToEnd();
            streamReader.Close();

            //拆分替换文本
            foreach (KeyValuePair<string, string> pair in dic)
            {
                s = s.Replace(pair.Key, pair.Value);
            }

            //保存替换后字段
            using StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8);
            streamWriter.WriteLine(s);
            streamWriter.Flush();
            streamWriter.Close();
        }
    }
}
