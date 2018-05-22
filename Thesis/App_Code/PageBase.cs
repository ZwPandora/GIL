using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using FineUI;



    public class PageBase : System.Web.UI.Page
    {
        #region OnInit

        protected override void OnInit(EventArgs e)
        {
            var pm = PageManager.Instance;

            // 如果不是FineUI的AJAX回发（两种情况：1.页面第一个加载 2.页面非AJAX回发）
            if (pm != null && !pm.IsFineUIAjaxPostBack)
            {
                HttpCookie themeCookie = Request.Cookies["Theme_v4"];
                if (themeCookie != null)
                {
                    try
                    {
                        string themeValue = themeCookie.Value;
                        pm.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Theme = FineUI.Theme.Neptune;
                    }
                }

                HttpCookie langCookie = Request.Cookies["Language_v4"];
                if (langCookie != null)
                {
                    try
                    {
                        string langValue = langCookie.Value;
                        pm.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Language = Language.ZH_CN;
                    }
                }
            }


            base.OnInit(e);
        }

        private bool IsSystemTheme(string themeName)
        {
            themeName = themeName.ToLower();
            string[] themes = Enum.GetNames(typeof(Theme));
            foreach (string theme in themes)
            {
                if (theme.ToLower() == themeName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 上传文件类型判断

        protected readonly static List<string> VALID_FILE_TYPES = new List<string> { "jpg", "bmp", "gif", "jpeg", "png" };

        protected static bool ValidateFileType(string fileName)
        {
            string fileType = String.Empty;
            int lastDotIndex = fileName.LastIndexOf(".");
            if (lastDotIndex >= 0)
            {
                fileType = fileName.Substring(lastDotIndex + 1).ToLower();
            }

            if (VALID_FILE_TYPES.Contains(fileType))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion


        #region 表格相关

        /// <summary>
        /// 选中了哪些行
        /// </summary>
        /// <param name="grid">表格对象</param>
        /// <returns>选中行的描述信息</returns>
        protected string HowManyRowsAreSelected(Grid grid)
        {
            return HowManyRowsAreSelected(grid, false);
        }

        /// <summary>
        /// 选中了哪些行
        /// </summary>
        /// <param name="grid">表格对象</param>
        /// <param name="rowNumberInDataSource">在表格数据源中计算序号（而不是在当前分页内计算序号）</param>
        /// <returns>选中行的描述信息</returns>
        protected string HowManyRowsAreSelected(Grid grid, bool rowNumberInDataSource)
        {
            StringBuilder sb = new StringBuilder();
            int selectedCount = grid.SelectedRowIndexArray.Length;
            if (selectedCount > 0)
            {
                sb.AppendFormat("<p><strong>共选中了 {0} 行：</strong></p>", selectedCount);
                sb.Append("<table class=\"result\">");

                sb.Append("<tr><th>序号</th>");
                foreach (string datakey in grid.DataKeyNames)
                {
                    sb.AppendFormat("<th>{0}</th>", datakey);
                }
                sb.Append("</tr>");


                for (int i = 0; i < selectedCount; i++)
                {
                    int rowIndex = grid.SelectedRowIndexArray[i];
                    sb.Append("<tr>");

                    int rownumber = rowIndex + 1;
                    if (rowNumberInDataSource && grid.AllowPaging)
                    {
                        rownumber += grid.PageIndex * grid.PageSize;
                    }
                    sb.AppendFormat("<td>{0}</td>", rownumber);


                    // 如果是内存分页，所有分页的数据都存在，rowIndex 就是在全部数据中的顺序，而不是当前页的顺序
                    if (grid.AllowPaging && !grid.IsDatabasePaging)
                    {
                        rowIndex = grid.PageIndex * grid.PageSize + rowIndex;
                    }

                    object[] dataKeys = grid.DataKeys[rowIndex];
                    for (int j = 0; j < dataKeys.Length; j++)
                    {
                        sb.AppendFormat("<td>{0}</td>", dataKeys[j]);
                    }

                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            else
            {
                sb.Append("<strong>没有选中任何一行！</strong>");
            }

            return sb.ToString();
        }

        /// <summary>
        /// 获取性别的字面值，在 ASPX 中调用
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        protected string GetGender(object gender)
        {
            if (Convert.ToInt32(gender) == 1)
            {
                return "男";
            }
            else
            {
                return "女";
            }
        }


        #endregion

        #region 压缩ViewState

        //protected override object LoadPageStateFromPersistenceMedium()
        //{
        //    string gzippedState = Request.Form[StringUtil.GZIPPED_VIEWSTATE_ID];
        //    return StringUtil.LoadGzippedViewState(gzippedState);
        //}

        //protected override void SavePageStateToPersistenceMedium(object viewState)
        //{
        //    ClientScript.RegisterHiddenField(StringUtil.GZIPPED_VIEWSTATE_ID, StringUtil.GenerateGzippedViewState(viewState));
        //} 

        #endregion

        #region 实用函数

        /// <summary>
        /// 获取回发的参数
        /// </summary>
        /// <returns></returns>
        public string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }


        /// <summary>
        /// 显示通知对话框
        /// </summary>
        /// <param name="message"></param>
        public void ShowNotify(string message)
        {
            Alert.Show(message);
        }

        #endregion

    }


