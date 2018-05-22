using System;
using System.Collections.Generic;

using System.Text;
using System.Reflection;
using System.Collections;

namespace thesis.common
{
    public class ReflectUtil
    {
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void SetProperty(object obj, string name, object value)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(name);
            if (propertyInfo == null) return;
            object objValue = Convert.ChangeType(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(obj, objValue, null);
        }

        /**/
        ///  <summary>
        /// 获取对象属性的值
        ///  </summary>
        public static object GetProperty(object obj, string name)
        {
            //bindingFlags
            PropertyInfo propertyInfo = obj.GetType().GetProperty(name);
            if (propertyInfo == null) return null;
            return propertyInfo.GetValue(obj, null);
        }
        /// <summary>
        /// 支持子对象属性获得的方法,列表类子属性可以按照 list.Item0.property形式访问
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="prop"></param>
        /// <returns></returns>
        public static object GetRecursivePropertyValue(object obj, string prop)
        {
            string ParentProperty = prop;
            string ChildProperty = "";
            if (prop.IndexOf('.') > 0)
            {
                ParentProperty = prop.Substring(0, prop.IndexOf('.'));
                ChildProperty = prop.Substring( prop.IndexOf('.')+1);
            }
            object ParentObj = null;
            //处理列表属性
            if (ParentProperty.StartsWith("Item") && (obj is IList))
            {
                IList list = (IList)obj;
                int index = int.Parse(ParentProperty.Substring(4));
                if (index >= 0 && index < list.Count)
                {
                    ParentObj = list[index];
                }
            }
            else
            {
                ParentObj = GetProperty(obj, ParentProperty);
            }
            if (ParentObj == null) return null;
            //如果有子属性则递归解析
            if (ChildProperty != "")
                return GetRecursivePropertyValue(ParentObj, ChildProperty);
            return ParentObj;
        }
    }
}
