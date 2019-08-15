using System;
using System.Collections.Generic;
using System.Reflection;
/// <summary>
/// 测试 .dll 文件的使用
/// 基础知识;
///     1：xxx.dll 文件的封装；VS==>创建类库==>进入项目里面写你要封装的代码==>点击 生成 按钮，生成解决方案，然后你到对应的项目文件夹下的 bin 文件的子目录里面会看到一个，项目名.dll 文件就是你要的；
///     2：xxx.dll 文件的名字是你创建的项目的名字也就是名称空间的名字，名称空间下面就是类的名称
/// 前提： 
///     将你封装好的 xxx.dll 文件放到项目下的bin的子文件夹里面
/// KeyNote:
///     _assembly.GetModules():获取作为此程序集的一部分的所有模块;
///     list转字符串;参考网站：https://blog.csdn.net/hellowangxyue/article/details/51126151
/// </summary>
namespace RefeectProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------------------\n\n");
            //获取程序集
            //Assembly _assembly = Assembly.Load("GameCC666");
            Assembly _assembly = Assembly.LoadFrom("GameCC666.dll");
            Type _type = _assembly.GetType("GameCC666.Animation");
            Console.WriteLine("程序集加载完毕！\n");
            //开始创建对象
            var _ani01 = Activator.CreateInstance(_type);
            var _ani02 = Activator.CreateInstance(_type, new Object[] { "gamecc666", 27 });
            var _ani03 = _assembly.CreateInstance("GameCC666.Animation");
            Module[] _mods=_assembly.GetModules();
            foreach(Module md in _mods)
            {
                Console.WriteLine("This is Assembly contains this {0} module\n", md.Name);
            }
            //获取程序集中所有的公共属性
            List<string> _propertylist = new List<string>();
            foreach(PropertyInfo pi in _type.GetProperties())
            {
                _propertylist.Add(pi.Name);
            }
            var _strpropertylist = string.Join("*||*", _propertylist);
            Console.WriteLine("公共属性的list字符串：{0}\n", _strpropertylist);
            //获取程序集中的所有公共字段
            List<string> _fieldlist = new List<string>();
            foreach(FieldInfo fi in _type.GetFields())
            {
                _fieldlist.Add(fi.Name);
            }
            var _strfieldlist = string.Join("*||*", _fieldlist);
            Console.WriteLine("公共字段的list字符串：{0}\n", _strfieldlist);
            //获得当前对象的所有公共方法
            List<string> _methodlist = new List<string>();
            foreach(MethodInfo mi in _type.GetMethods())
            {
                _methodlist.Add(mi.Name);
            }
            var _strmethodlist = string.Join("*||*", _methodlist);
            Console.WriteLine("公共方法的字符串：{0}\n", _strmethodlist);
            //调用public函数（无参数）
            _type.InvokeMember("GetAnimationName",
                               BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Instance, null, _ani03, null);
            //调用public函数（带参数）
            string _res = _type.InvokeMember("SayHello", BindingFlags.InvokeMethod, null, _ani03, new object[] { "gamecc777" }) as string;
            Console.WriteLine("\n调用带参数的public函数，函数的返回结果是：{0}",_res);
            //调用静态方法
            string _staticres = _type.InvokeMember("CallMethod",BindingFlags.InvokeMethod|BindingFlags.Public|BindingFlags.Static,null,null,null)as string;
            Console.WriteLine("\n调用静态方法；返回结果：{0}" , _staticres);

            Console.WriteLine("\n\n------------------------------------------------------------\nGameCC666测试完毕！!");
            Console.ReadKey();
        }
    }
}
