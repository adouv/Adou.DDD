using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
using Adou.Entity.PetaPocoModels.AdouModel;

namespace Adou.Repositories.PetaPoco.Adou
{
    /// <summary>
    /// 产品管理服务
    /// </summary>
    public class WebProductRep : BaseRep<adWebProduct>
    {
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns></returns>
        public IEnumerable<adWebProduct> GetWebProductList(string orderBy, bool isDesc, adWebProduct model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            //产品名称
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                sqlWhere += " AND [Name] LIKE '%@0%' ";
            }
            //产品分类
            if (model.ProductTypeId > 0)
            {
                sqlWhere += " AND [ProductTypeId] = @1 ";
            }
            //品种
            if (model.VarietyId > 0)
            {
                sqlWhere += " AND [VarietyId] = @2 ";
            }
            //规格
            if (!string.IsNullOrWhiteSpace(model.Specification))
            {
                sqlWhere += " AND [Specification] LIKE '%@3%' ";
            }
            //几孔
            if (model.FewHolesId > 0)
            {
                sqlWhere += " AND [FewHolesId] = @4 ";
            }
            //锌层
            if (model.ZincLayerId > 0)
            {
                sqlWhere += " AND [ZincLayerId] = @5 ";
            }
            //颜色
            if (model.ColorId > 0)
            {
                sqlWhere += " AND [ColorId] = @6 ";
            }
            //数量
            if (!string.IsNullOrWhiteSpace(model.Quantity))
            {
                sqlWhere += " AND [Quantity] LIKE '%@7%' ";
            }
            //公司名称
            if (!string.IsNullOrWhiteSpace(model.CompanyName))
            {
                sqlWhere += " AND [CompanyName] LIKE '%@8%' ";
            }
            //用户编号
            if (model.UserId > 0)
            {
                sqlWhere += " AND [UserId] = @9 ";
            }
            //用户名
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sqlWhere += " AND [UserName] LIKE '%@10%' ";
            }
            //是否热点
            if (model.IsHot > -1)
            {
                sqlWhere += " AND [IsHot] = @11 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[Name]
                    ,[ProductTypeId]
                    ,[VarietyId]
                    ,[Specification]
                    ,[FewHolesId]
                    ,[ZincLayerId]
                    ,[ColorId]
                    ,[Quantity]
                    ,[CompanyName]
                    ,[UserId]
                    ,[UserName]
                    ,[IsHot]
                    ,[IsDel]
                    ,[Sort]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                FROM [dbo].[adWebProduct]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetList(orderBy, isDesc, sql,
                model.Name,
                model.ProductTypeId,
                model.VarietyId,
                model.Specification,
                model.FewHolesId,
                model.ZincLayerId,
                model.ColorId,
                model.Quantity,
                model.CompanyName,
                model.UserId,
                model.UserName,
                model.IsHot);
        }
        /// <summary>
        /// 分页获取产品列表
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页条数</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="isDes">是否倒序</param>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public Page<adWebProduct> GetWebProductPageList(int pageIndex, int pageSize, string orderBy, bool isDesc, adWebProduct model)
        {
            string sqlWhere = string.Empty;
            string sql = string.Empty;

            #region where
            //产品名称
            if (!string.IsNullOrWhiteSpace(model.Name))
            {
                sqlWhere += " AND [Name] LIKE '%@0%' ";
            }
            //产品分类
            if (model.ProductTypeId > 0)
            {
                sqlWhere += " AND [ProductTypeId] = @1 ";
            }
            //品种
            if (model.VarietyId > 0)
            {
                sqlWhere += " AND [VarietyId] = @2 ";
            }
            //规格
            if (!string.IsNullOrWhiteSpace(model.Specification))
            {
                sqlWhere += " AND [Specification] LIKE '%@3%' ";
            }
            //几孔
            if (model.FewHolesId > 0)
            {
                sqlWhere += " AND [FewHolesId] = @4 ";
            }
            //锌层
            if (model.ZincLayerId > 0)
            {
                sqlWhere += " AND [ZincLayerId] = @5 ";
            }
            //颜色
            if (model.ColorId > 0)
            {
                sqlWhere += " AND [ColorId] = @6 ";
            }
            //数量
            if (!string.IsNullOrWhiteSpace(model.Quantity))
            {
                sqlWhere += " AND [Quantity] LIKE '%@7%' ";
            }
            //公司名称
            if (!string.IsNullOrWhiteSpace(model.CompanyName))
            {
                sqlWhere += " AND [CompanyName] LIKE '%@8%' ";
            }
            //用户编号
            if (model.UserId > 0)
            {
                sqlWhere += " AND [UserId] = @9 ";
            }
            //用户名
            if (!string.IsNullOrWhiteSpace(model.UserName))
            {
                sqlWhere += " AND [UserName] LIKE '%@10%' ";
            }
            //是否热点
            if (model.IsHot > -1)
            {
                sqlWhere += " AND [IsHot] = @11 ";
            }
            #endregion

            #region sql
            sql = string.Format(@"
                SELECT [Id]
                    ,[Name]
                    ,[ProductTypeId]
                    ,[VarietyId]
                    ,[Specification]
                    ,[FewHolesId]
                    ,[ZincLayerId]
                    ,[ColorId]
                    ,[Quantity]
                    ,[CompanyName]
                    ,[UserId]
                    ,[UserName]
                    ,[IsHot]
                    ,[IsDel]
                    ,[Sort]
                    ,[CreateTime]
                    ,[CreateUser]
                    ,[ModifyTime]
                    ,[ModifyUser]
                FROM [dbo].[adWebProduct]
                WHERE 1=1 AND [IsDel] = 0 {0} 
            ", sqlWhere);
            #endregion

            return this.GetPageList(orderBy, isDesc, pageIndex, pageSize, sql,
                model.Name,
                model.ProductTypeId,
                model.VarietyId,
                model.Specification,
                model.FewHolesId,
                model.ZincLayerId,
                model.ColorId,
                model.Quantity,
                model.CompanyName,
                model.UserId,
                model.UserName,
                model.IsHot);
        }
        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns>long</returns>
        public long InsertWebProduct(adWebProduct model)
        {
            this.Insert(model);
            return model.Id;
        }
        /// <summary>
        /// 修改产品
        /// </summary>
        /// <param name="model">请求参数</param>
        /// <returns>long</returns>
        public long UpdateWebProductById(adWebProduct model)
        {
            string sql = string.Empty;

            #region sql
            sql = string.Format(@"
                SET [Name] = @0
                    ,[ProductTypeId] = @1
                    ,[VarietyId] = @2
                    ,[Specification] = @3
                    ,[FewHolesId] = @4
                    ,[ZincLayerId] = @5
                    ,[ColorId] = @6
                    ,[Quantity] = @7
                    ,[CompanyName] = @8
                    ,[UserId] = @9
                    ,[UserName] = @10
                    ,[IsHot] = @11
                    ,[Sort] = @12
                    ,[ModifyTime] = @13
                    ,[ModifyUser] = @14
                WHERE 1 = 1 AND [Id] = @15
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adWebProduct>(sql,
                model.Name,
                model.ProductTypeId,
                model.VarietyId,
                model.Specification,
                model.FewHolesId,
                model.ZincLayerId,
                model.ColorId,
                model.Quantity,
                model.CompanyName,
                model.UserId,
                model.UserName,
                model.IsHot,
                model.Sort,
                model.ModifyTime,
                model.ModifyUser,
                model.Id);
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public int DeleteWebProductById(long id)
        {
            return this.Delete(id);
        }
        /// <summary>
        /// 伪删除
        /// </summary>
        /// <param name="model">请求实体</param>
        /// <returns></returns>
        public int UpdateWebProductIsDelById(adWebProduct model)
        {
            #region sql
            string sql = string.Format(@"
                SET [IsDel] = @0
                    ,[ModifyTime] = @1
                    ,[ModifyUser] = @2
                WHERE 1 = 1 AND [Id] = @3
            ");
            #endregion

            return PetaPocoAdouDB.GetInstance().Update<adWebProduct>(sql, model.IsDel, model.ModifyTime, model.ModifyUser, model.Id);
        }
    }
}
