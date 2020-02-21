using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class CreateMaterial : EditorWindow
{
    [MenuItem("Window/CreateMaterial")]
    static void Applay()
    {
        Rect wr = new Rect(0, 0, 400, 200);
        CreateMaterial window = (CreateMaterial)EditorWindow.GetWindowWithRect(typeof(CreateMaterial), wr, true, "CreateMaterial");
        window.Show();
    }

    void OnGUI()
    {
        if (GUILayout.Button("选中文件夹生成Material", GUILayout.Height(50), GUILayout.Width(400)))
        {
            CreateMaterials();

        }
        if (GUILayout.Button("生成女朋友", GUILayout.Height(50), GUILayout.Width(400)))
        {
            this.ShowNotification(new GUIContent("做梦吧"));
        }

    }
    void CreateMaterials()
    {
        string[] folder = FindAllFolders("拆分图片", "Assets/ArtResource/Animation");
        //string[] tex = new string[] { };

        //List<string> texList = new List<string>();
        foreach (var fullPath in folder)
        {
            //Debug.Log(fullPath);
            //获取指定路径下面的所有资源文件  
            if (Directory.Exists(fullPath))
            {
                DirectoryInfo direction = new DirectoryInfo(fullPath);
                FileInfo[] files = direction.GetFiles("*", SearchOption.AllDirectories);
                List<string> tex1 = new List<string>();
                //Debug.Log(files.Length);
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Name.EndsWith(".png"))
                    {
                        tex1.Add(fullPath + '/' + files[i].Name);
                        // Debug.Log(fullPath + '/' + files[i].Name);
                    }
                    if (files[i].Name.EndsWith(".mat"))
                    {
                        //tex1 = null;
                        tex1.Clear();
                        break;
                    }
                    //Debug.Log("Name:" + files[i].Name);
                    //Debug.Log( "FullName:" + files[i].FullName );  
                    //Debug.Log( "DirectoryName:" + files[i].DirectoryName );  
                }
                //texList = texList.Concat(tex1).ToList<string>();
                if (tex1.Count > 0)
                {
                    foreach (string texAddress in tex1)
                    {
                        Material m = new Material(Shader.Find("Unlit/SpriteCullOff"));
                        Texture t = AssetDatabase.LoadAssetAtPath<Texture>(texAddress);
                        if (m != null && t != null)
                        {
                            m.color = Color.white;
                            m.mainTexture = t;
                            string matAddress = fullPath + "/Material" + tex1.IndexOf(texAddress)+".mat";
                            AssetDatabase.CreateAsset(m, matAddress);
                            Debug.Log(matAddress);

                        }
                        else
                        {
                            if (m == null)
                                this.ShowNotification(new GUIContent("MaterialCreateError"));
                            if (t == null)
                                this.ShowNotification(new GUIContent("TextureCreateError"));
                        }
                    }
                }
            }
        }


    }
    static string[] FindAllFolders(string folderName, string searchInFolders)
    {
        if (AssetDatabase.IsValidFolder(searchInFolders))
        {
            string[] guids1 = AssetDatabase.FindAssets("拆分图片", new[] { searchInFolders });
            //string[] guids1 = AssetDatabase.FindAssets(folderName);
            for (int i = 0; i < guids1.Length; i++)
            {
                guids1[i] = AssetDatabase.GUIDToAssetPath(guids1[i]);
            }
            return guids1;
        }
        else
        {
            Debug.LogError("folderNameError");
            return null;
        }

    }

}