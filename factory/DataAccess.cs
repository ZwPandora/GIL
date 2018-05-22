using System;
using System.Reflection;
using System.Configuration;
using thesis.idal;
using thesis.common;
namespace thesis.factory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationSettings.AppSettings["dal"];
        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string path, string CacheKey)
        {
            object objType = DataCache.GetCache(CacheKey);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(path).CreateInstance(CacheKey);//反射创建
                    DataCache.SetCache(CacheKey, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }

        /// <summary>
        /// 创建RoleDal数据层接口
        /// </summary>
        public static thesis.idal.IRoleDal CreateRoleDal()
        {

            string CacheKey = path + ".RoleDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IRoleDal)objType;
        }

        /// <summary>
        /// 创建CAUSE数据层接口
        /// </summary>
        public static IICS_OBQXDal CreateICS_OBQXDal()
        {

            string CacheKey = path + ".ICS_OBQXDal";
            object objType = CreateObject(path, CacheKey);
            return (IICS_OBQXDal)objType;
        }
        public static IICS_ROLEDal CreateICS_ROLEDal()
        {

            string CacheKey = path + ".ICS_RoleDal";
            object objType = CreateObject(path, CacheKey);
            return (IICS_ROLEDal)objType;
        }
        public static IICS_ROLEGLDal CreateICS_ROLEGLDal()
        {

            string CacheKey = path + ".ICS_ROLEGLDal";
            object objType = CreateObject(path, CacheKey);
            return (IICS_ROLEGLDal)objType;
        }
        public static IICS_THEME_CONTENTDal CreateICS_THEME_CONTENTDal()
        {

            string CacheKey = path + ".ICS_THEME_CONTENTDal";
            object objType = CreateObject(path, CacheKey);
            return (IICS_THEME_CONTENTDal)objType;
        }
        public static IICS_TREEDal CreateICS_TREEDal()
        {

            string CacheKey = path + ".ICS_TREEDal";
            object objType = CreateObject(path, CacheKey);
            return (IICS_TREEDal)objType;
        }

        /// <summary>
        /// 创建RoleDal数据层接口
        /// </summary>
        public static thesis.idal.IRoleglDal CreateRoleglDal()
        {

            string CacheKey = path + ".RoleglDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IRoleglDal)objType;
        }

        /// <summary>
        /// 创建RoleDal数据层接口
        /// </summary>
        public static thesis.idal.ICompanyDal CreateCompanyDal()
        {

            string CacheKey = path + ".CompanyDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.ICompanyDal)objType;
        }

        /// <summary>
        /// 创建RoleDal数据层接口
        /// </summary>
        public static thesis.idal.IDepartmentDal CreateDepartmentDal()
        {

            string CacheKey = path + ".DepartmentDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IDepartmentDal)objType;
        }

        /// <summary>
        /// 创建RoleDal数据层接口
        /// </summary>
        public static thesis.idal.IOfficeDal CreateOfficeDal()
        {

            string CacheKey = path + ".OfficeDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IOfficeDal)objType;
        }

        public static thesis.idal.IWeb_NodeDal CreateWeb_NodeDal()
        {

            string CacheKey = path + ".Web_NodeDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IWeb_NodeDal)objType;
        }

        /// <summary>
        /// 创建UserDal数据层接口
        /// </summary>
        public static thesis.idal.IUserDal CreateUserDal()
        {

            string CacheKey = path + ".UserDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IUserDal)objType;
        }
        /// <summary>
        /// 创建OBQX数据层接口
        /// </summary>
        /// <summary>
        /// 创建OBQX数据层接口
        /// </summary>
        public static thesis.idal.IObjectRangeDal_Web CreateObjectRangeDal_Web()
        {

            string CacheKey = path + ".ObjectRangeDal_Web";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IObjectRangeDal_Web)objType;
        }
        /// <summary>
        /// 创建LoginRecord数据层接口
        /// </summary>
        public static thesis.idal.ILoginRecord CreateLoginRecordDal()
        {

            string CacheKey = path + ".LoginRecordDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.ILoginRecord)objType;
        }
        public static thesis.idal.IOperationLogDal CreateOperationLogDal()
        {

            string CacheKey = path + ".OperationLogDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IOperationLogDal)objType;
        }

        public static thesis.idal.IFailureModeDal CreateFailureModeDal()
        {

            string CacheKey = path + ".FailureModeDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFailureModeDal)objType;
        }

        public static thesis.idal.IMalfunctionDal CreateMalfunctionDal()
        {

            string CacheKey = path + ".MalfunctionDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IMalfunctionDal)objType;
        }

        public static thesis.idal.IFaultCaseBaseDal CreateFaultCaseBaseDal()
        {

            string CacheKey = path + ".FaultCaseBaseDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFaultCaseBaseDal)objType;
        }

        public static thesis.idal.IRiskFactor CreateRiskFactorDal()
        {

            string CacheKey = path + ".RiskFactorDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IRiskFactor)objType;
        }

        public static thesis.idal.IEvaluationCriteriaDal CreateEvaluationCriteriaDal()
        {

            string CacheKey = path + ".EvaluationCriteriaDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IEvaluationCriteriaDal)objType;
        }

        public static thesis.idal.IFMEAItemDal CreateFMEAItemDal()
        {

            string CacheKey = path + ".FMEAItemDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFMEAItemDal)objType;
        }

        public static thesis.idal.IFI_FMDal CreateFI_FMDal()
        {

            string CacheKey = path + ".FI_FMDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFI_FMDal)objType;
        }

        public static thesis.idal.IFI_RFDal CreateFI_RFDal()
        {

            string CacheKey = path + ".FI_RFDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFI_RFDal)objType;
        }

        public static thesis.idal.IEvaluationDal CreateEvaluationDal()
        {

            string CacheKey = path + ".EvaluationDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IEvaluationDal)objType;
        }

        public static thesis.idal.IFM_IndexsDal CreateFM_IndexsDal()
        {

            string CacheKey = path + ".FM_IndexsDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFM_IndexsDal)objType;
        }

        public static thesis.idal.IComponentDal CreateComponentDal()
        {

            string CacheKey = path + ".ComponentDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IComponentDal)objType;
        }

        public static thesis.idal.IIndexSystemDal CreateIndexSystemDal()
        {

            string CacheKey = path + ".IndexSystemDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IIndexSystemDal)objType;
        }

        public static thesis.idal.ICORRELATIONSHIPDal CreateCORRELATIONSHIPDal()
        {

            string CacheKey = path + ".CORRELATIONSHIPDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.ICORRELATIONSHIPDal)objType;
        }

        public static thesis.idal.IExpertInfoDal CreateExpertInfoDal()
        {

            string CacheKey = path + ".ExpertInfoDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IExpertInfoDal)objType;
        }

        public static thesis.idal.IGISINFO CreateGISINFODal()
        {

            string CacheKey = path + ".GISINFODal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IGISINFO)objType;
        }

        public static thesis.idal.IFI_ExpDal CreateFI_ExpDal()
        {

            string CacheKey = path + ".FI_ExpDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IFI_ExpDal)objType;
        }

        public static thesis.idal.IGILIndexDal CreateGILIndexDal()
        {

            string CacheKey = path + ".GILIndexDal";
            object objType = CreateObject(path, CacheKey);
            return (thesis.idal.IGILIndexDal)objType;
        }

       

    }
}
