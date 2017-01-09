using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 乐智知识库
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            this.textBox1.Text = @"实际上是一个文件管理器，哈哈，方便自己用
程序是读取kb目录下的文件夹及文件，可以将平时记录的资料放到分类好的文件夹下，也支持其他文件，只有txt文件可以直接读到文本框里，其他的文件会使用默认关联的程序打开
可以加下面QQ群
第二世界 304477390
更新预览：
    加入新建文本功能
    完成基本设置
    加入


更新日志：
2016-4-26：加入了请求管理员权限用以支持开机自启        
2016-4-25：1.03优化:收藏文件不存在时不能自动删除；增加删除收藏的功能，设置新增界面
2016-4-22：1.02文本编码持久化保存，下次打开还是上一次设置的编码；编码选择菜单项前加入了勾选符号
2016-1-13：1.01优化提示在全屏后的位置，快捷键打开知识库目录，方便了文件的新建等
2016-1-11：1.0版本

";
        }
    }
}
