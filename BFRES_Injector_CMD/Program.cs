using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syroot.NintenTools.Bfres;
using Syroot.NintenTools.Bfres.Helpers;
using OpenTK;

namespace BFRES_Injector_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\n> BFRES Injector v2.0a\n" +
                               "> Made by SMB123W64GB\n" +
                                "> Using Syroot.NintenTools.Bfres API\n" +
                                "> *.bfres *.obj/*.smd\n");

            ResFile TargetBFRES = new ResFile(args[0]);
            MeshObj test = new MeshObj();
            test.ReadObj(args[1]);
            test.InjectMesh(TargetBFRES.Models[0], TargetBFRES.ByteOrder);
            TargetBFRES.Models[0].Materials[0].RenderState.PolygonControl.CullBack = false;
            TargetBFRES.Models[0].Materials[0].RenderState.PolygonControl.CullFront = false;
            TargetBFRES.Models[0].Materials[0].RenderState.PolygonControl.PolygonModeEnabled = true;
            TargetBFRES.Name = "A_Cool_Mesh";
            Console.WriteLine("Writing {0}",args[0] + ".new.bfres");
            TargetBFRES.Save(args[0] + ".new.bfres");
        }

        

        public class MeshObj
        {
            public void InjectMesh(Model input,Syroot.BinaryData.ByteOrder BO)
            {
                //Deal With Mesh
                uint[] theFaces = meshes[0].faces.ToArray();
                input.Shapes[0].Meshes[0].SetIndices(theFaces);
                if(input.Shapes[0].Meshes.Count!=1) for (int i = 0; i < input.Shapes[0].Meshes.Count; i++) input.Shapes[0].Meshes.RemoveAt(1);
                input.Shapes[0].Radius = 10000000000f;

                input.Shapes[0].Meshes[0].SubMeshes.Clear();
                Bounding LeeT = new Bounding();
                LeeT.Center = new Syroot.Maths.Vector3F(0,0,0);
                LeeT.Extent = new Syroot.Maths.Vector3F(10000000000f, 10000000000f, 10000000000f);
                for (int i = 0; i < input.Shapes[0].SubMeshBoundings.Count; i++) input.Shapes[0].SubMeshBoundings[i] = LeeT;

                SubMesh Setup = new SubMesh();
                Setup.Count = (uint)meshes[0].faces.Count;
                Setup.Offset = 0;
                for(int vvv = 0;vvv<4;vvv++) input.Shapes[0].Meshes[0].SubMeshes.Add(Setup);
                //input.Shapes[0].Name = meshes[0].Name;
                //Deal with Vertexes
                VertexBufferHelper helper = new VertexBufferHelper(input.VertexBuffers[0], BO);
                List<VertexBufferHelperAttrib> atrib = new List<VertexBufferHelperAttrib>();
                VertexBufferHelperAttrib vertPos = new VertexBufferHelperAttrib();
                vertPos.Name = "_p0";
                vertPos.Data = meshes[0].verts.ToArray();
                vertPos.Format = Syroot.NintenTools.Bfres.GX2.GX2AttribFormat.Format_16_16_16_16_Single;
                VertexBufferHelperAttrib vertUV = new VertexBufferHelperAttrib();
                vertUV.Name = "_u0";
                vertUV.Data = meshes[0].uvs.ToArray();
                vertUV.Format = Syroot.NintenTools.Bfres.GX2.GX2AttribFormat.Format_16_16_Single;
                VertexBufferHelperAttrib vertNorm = new VertexBufferHelperAttrib();
                vertNorm.Name = "_n0";
                vertNorm.Data = meshes[0].norms.ToArray();
                vertNorm.Format = Syroot.NintenTools.Bfres.GX2.GX2AttribFormat.Format_10_10_10_2_SNorm;
                atrib.Add(vertPos);
                atrib.Add(vertNorm);
                atrib.Add(vertUV);
                helper.Attributes = atrib;
                input.VertexBuffers[0] = helper.ToVertexBuffer();

                }
            public void InjectMeshRigged(Model input, Syroot.BinaryData.ByteOrder BO)
            {
                //Deal With Mesh
                uint[] theFaces = meshes[0].faces.ToArray();
                input.Shapes[0].Meshes[0].SetIndices(theFaces);
                if (input.Shapes[0].Meshes.Count != 1) for (int i = 0; i < input.Shapes[0].Meshes.Count; i++) input.Shapes[0].Meshes.RemoveAt(1);
                input.Shapes[0].Radius = 10000000000f;

                input.Shapes[0].Meshes[0].SubMeshes.Clear();
                Bounding LeeT = new Bounding();
                LeeT.Center = new Syroot.Maths.Vector3F(0, 0, 0);
                LeeT.Extent = new Syroot.Maths.Vector3F(10000000000f, 10000000000f, 10000000000f);
                for (int i = 0; i < input.Shapes[0].SubMeshBoundings.Count; i++) input.Shapes[0].SubMeshBoundings[i] = LeeT;

                SubMesh Setup = new SubMesh();
                Setup.Count = (uint)meshes[0].faces.Count;
                Setup.Offset = 0;
                for (int vvv = 0; vvv < 4; vvv++) input.Shapes[0].Meshes[0].SubMeshes.Add(Setup);
                //input.Shapes[0].Name = meshes[0].Name;
                //Deal with Vertexes
                VertexBufferHelper helper = new VertexBufferHelper(input.VertexBuffers[0], BO);
                List<VertexBufferHelperAttrib> atrib = new List<VertexBufferHelperAttrib>();
                VertexBufferHelperAttrib vertPos = new VertexBufferHelperAttrib();
                vertPos.Name = "_p0";
                vertPos.Data = meshes[0].verts.ToArray();
                vertPos.Format = Syroot.NintenTools.Bfres.GX2.GX2AttribFormat.Format_16_16_16_16_Single;
                VertexBufferHelperAttrib vertUV = new VertexBufferHelperAttrib();
                vertUV.Name = "_u0";
                vertUV.Data = meshes[0].uvs.ToArray();
                vertUV.Format = Syroot.NintenTools.Bfres.GX2.GX2AttribFormat.Format_16_16_Single;
                VertexBufferHelperAttrib vertNorm = new VertexBufferHelperAttrib();
                vertNorm.Name = "_n0";
                vertNorm.Data = meshes[0].norms.ToArray();
                vertNorm.Format = Syroot.NintenTools.Bfres.GX2.GX2AttribFormat.Format_10_10_10_2_SNorm;
                atrib.Add(vertPos);
                atrib.Add(vertNorm);
                atrib.Add(vertUV);
                helper.Attributes = atrib;
                input.VertexBuffers[0] = helper.ToVertexBuffer();

            }
            public class SMesh
            {
                public string Name;
                public List<Syroot.Maths.Vector4F> verts = new List<Syroot.Maths.Vector4F>();
                //Always make the last of the vec4 1.0 (idk what it is)
                public List<Syroot.Maths.Vector4F> norms = new List<Syroot.Maths.Vector4F>();
                //Last of vec4 is 0 fornow
                public List<Syroot.Maths.Vector4F> uvs = new List<Syroot.Maths.Vector4F>();
                public List<Syroot.Maths.Vector4F> boneINDX = new List<Syroot.Maths.Vector4F>();
                public List<Syroot.Maths.Vector4F> boneWGHT = new List<Syroot.Maths.Vector4F>();
                public IList<uint> faces = new List<uint>();
                public List<List<string>> rawFace = new List<List<string>>();
            }
            public List<SMesh> meshes = new List<SMesh>();
            public void ReadSMD(string File,Skeleton BaseModel)
            {

            }
            public void ReadObj(string File)
            {
                List<Syroot.Maths.Vector4F> verts = new List<Syroot.Maths.Vector4F>();
                List<Syroot.Maths.Vector4F> norms = new List<Syroot.Maths.Vector4F>();
                List<Syroot.Maths.Vector4F> uvs = new List<Syroot.Maths.Vector4F>();

                SMesh CMesh = new SMesh();
                string[] text = System.IO.File.ReadAllLines(File);
                //Import the obj
                foreach(string l in text)
                {
                    if(l.Contains("o "))
                    {
                        CMesh = new SMesh();
                        meshes.Add(CMesh);
                        CMesh.Name = l.Remove(0, 2);
                    }
                    if (l.Contains("v "))
                    {
                        string[] vertArry = l.Remove(0, 2).Split(' ');
                        verts.Add(new Syroot.Maths.Vector4F(float.Parse(vertArry[0]), float.Parse(vertArry[1]), float.Parse(vertArry[2]),1.0f));
                    }
                    if (l.Contains("vn "))
                    {
                        string[] vertArry = l.Remove(0, 3).Split(' ');
                        norms.Add(new Syroot.Maths.Vector4F(float.Parse(vertArry[0]), float.Parse(vertArry[1]), float.Parse(vertArry[2]), 0.0f));
                    }
                    if (l.Contains("vt "))
                    {
                        string[] vertArry = l.Remove(0, 3).Split(' ');
                        uvs.Add(new Syroot.Maths.Vector4F(float.Parse(vertArry[0]), float.Parse(vertArry[1])*-1,0f,0f));
                    }
                    if (l.Contains("f "))
                    {
                        string[] vertArry = l.Remove(0, 2).Split(' ');
                        if (vertArry.Length > 3) Console.WriteLine("Non-Traingulated Mesh\tPlease Re-Export with triangulated Mesh");
                        List<string> faceArray = new List<string>();
                        CMesh.rawFace.Add(new List<string>(vertArry.OfType<string>().ToList()));
                    }
                }
                //Time To Clean Our OBJ
                foreach(SMesh sm in meshes)
                {
                    List<Vector3> points = new List<Vector3>();
                    Dictionary<string, uint> lookup = new Dictionary<string, uint>();
                    uint fi = 0;
                    foreach(List<string> faceRaw in sm.rawFace)
                    {
                        foreach(string f in faceRaw)
                        {
                            if (!lookup.ContainsKey(f))
                            {
                                lookup.Add(f, fi);
                                sm.faces.Add(fi++);
                                string[] sr = f.Split('/');
                                sm.verts.Add(verts[int.Parse(sr[0]) - 1]);
                                sm.uvs.Add(uvs[int.Parse(sr[1]) - 1]);
                                sm.norms.Add(norms[int.Parse(sr[2]) - 1]);
                            }
                            else
                                sm.faces.Add(lookup[f]);
                            

                        }
                    }
                }

            }

        }
    }
}
