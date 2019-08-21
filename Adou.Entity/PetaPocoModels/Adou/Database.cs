
// This file was automatically generated by the PetaPoco T4 Template
// Do not make changes directly to this file - edit the template instead
// 
// The following connection settings were used to generate this file
// 
//     Connection String Name: `AdouConnection`
//     Provider:               `System.Data.SqlClient`
//     Connection String:      `Data Source=.;Initial Catalog=adou;MultipleActiveResultSets=True;user id=sa;password=**zapped**;`
//     Schema:                 ``
//     Include Views:          `False`

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetaPoco;

namespace Adou.Entity.PetaPocoModels.AdouModel
{
	public partial class PetaPocoAdouDB : Database
	{
		public PetaPocoAdouDB() 
			: base("AdouConnection")
		{
			CommonConstruct();
		}

		public PetaPocoAdouDB(string connectionStringName) 
			: base(connectionStringName)
		{
			CommonConstruct();
		}
		
		partial void CommonConstruct();
		
		public interface IFactory
		{
			PetaPocoAdouDB GetInstance();
		}
		
		public static IFactory Factory { get; set; }
        public static PetaPocoAdouDB GetInstance()
        {
			if (_instance!=null)
				return _instance;
				
			if (Factory!=null)
				return Factory.GetInstance();
			else
				return new PetaPocoAdouDB();
        }

		[ThreadStatic] static PetaPocoAdouDB _instance;
		
		public override void OnBeginTransaction()
		{
			if (_instance==null)
				_instance=this;
		}
		
		public override void OnEndTransaction()
		{
			if (_instance==this)
				_instance=null;
		}
        
		public class Record<T> where T:new()
		{
			public static PetaPocoAdouDB repo { get { return PetaPocoAdouDB.GetInstance(); } }
			public bool IsNew() { return repo.IsNew(this); }
			public object Insert() { return repo.Insert(this); }
			public void Save() { repo.Save(this); }
			public int Update() { return repo.Update(this); }
			public int Update(IEnumerable<string> columns) { return repo.Update(this, columns); }
			public static int Update(string sql, params object[] args) { return repo.Update<T>(sql, args); }
			public static int Update(Sql sql) { return repo.Update<T>(sql); }
			public int Delete() { return repo.Delete(this); }
			public static int Delete(string sql, params object[] args) { return repo.Delete<T>(sql, args); }
			public static int Delete(Sql sql) { return repo.Delete<T>(sql); }
			public static int Delete(object primaryKey) { return repo.Delete<T>(primaryKey); }
			public static bool Exists(object primaryKey) { return repo.Exists<T>(primaryKey); }
			public static bool Exists(string sql, params object[] args) { return repo.Exists<T>(sql, args); }
			public static T SingleOrDefault(object primaryKey) { return repo.SingleOrDefault<T>(primaryKey); }
			public static T SingleOrDefault(string sql, params object[] args) { return repo.SingleOrDefault<T>(sql, args); }
			public static T SingleOrDefault(Sql sql) { return repo.SingleOrDefault<T>(sql); }
			public static T FirstOrDefault(string sql, params object[] args) { return repo.FirstOrDefault<T>(sql, args); }
			public static T FirstOrDefault(Sql sql) { return repo.FirstOrDefault<T>(sql); }
			public static T Single(object primaryKey) { return repo.Single<T>(primaryKey); }
			public static T Single(string sql, params object[] args) { return repo.Single<T>(sql, args); }
			public static T Single(Sql sql) { return repo.Single<T>(sql); }
			public static T First(string sql, params object[] args) { return repo.First<T>(sql, args); }
			public static T First(Sql sql) { return repo.First<T>(sql); }
			public static List<T> Fetch(string sql, params object[] args) { return repo.Fetch<T>(sql, args); }
			public static List<T> Fetch(Sql sql) { return repo.Fetch<T>(sql); }
			public static List<T> Fetch(long page, long itemsPerPage, string sql, params object[] args) { return repo.Fetch<T>(page, itemsPerPage, sql, args); }
			public static List<T> Fetch(long page, long itemsPerPage, Sql sql) { return repo.Fetch<T>(page, itemsPerPage, sql); }
			public static List<T> SkipTake(long skip, long take, string sql, params object[] args) { return repo.SkipTake<T>(skip, take, sql, args); }
			public static List<T> SkipTake(long skip, long take, Sql sql) { return repo.SkipTake<T>(skip, take, sql); }
			public static Page<T> Page(long page, long itemsPerPage, string sql, params object[] args) { return repo.Page<T>(page, itemsPerPage, sql, args); }
			public static Page<T> Page(long page, long itemsPerPage, Sql sql) { return repo.Page<T>(page, itemsPerPage, sql); }
			public static IEnumerable<T> Query(string sql, params object[] args) { return repo.Query<T>(sql, args); }
			public static IEnumerable<T> Query(Sql sql) { return repo.Query<T>(sql); }
		}
	}
	

	/// <summary>
	/// 
	/// </summary>    
	[TableName("dbo.adAccount")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class adAccount : PetaPocoAdouDB.Record<adAccount>  
    {
		/// <summary>
		/// 
		/// </summary>
		[Column] public long Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Url { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Account { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Password { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Mobile { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Keyword { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Descript { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long CreateUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime ModifyTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long ModifyUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public bool IsDel { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public int? Sort { get; set; }
		/// <summary>
		/// 0个人 1公司 2
		/// </summary>
		[Column] public int? Type { get; set; }
	}
	/// <summary>
	/// 
	/// </summary>    
	[TableName("dbo.adMenu")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class adMenu : PetaPocoAdouDB.Record<adMenu>  
    {
		/// <summary>
		/// 
		/// </summary>
		[Column] public long Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string Title { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string MenuIcon { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string MenuUrl { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? FatherId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? LevelId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? CreateUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime? ModifyTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? ModifyUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public bool? IsDel { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public int? Sort { get; set; }
	}
	/// <summary>
	/// 
	/// </summary>    
	[TableName("dbo.adRole")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class adRole : PetaPocoAdouDB.Record<adRole>  
    {
		/// <summary>
		/// 
		/// </summary>
		[Column] public long Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string RoleName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string CreateUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime? ModifyTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string ModifyUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public bool? IsDel { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public int? Sort { get; set; }
	}
	/// <summary>
	/// 
	/// </summary>    
	[TableName("dbo.adUser")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class adUser : PetaPocoAdouDB.Record<adUser>  
    {
		/// <summary>
		/// 
		/// </summary>
		[Column] public long Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string UserName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string UserPwd { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string UserHead { get; set; }
		/// <summary>
		/// 1为超级管理员 0为分配管理员
		/// </summary>
		[Column] public int? UserType { get; set; }
		/// <summary>
		/// 0禁用  1可用
		/// </summary>
		[Column] public int? UserStatus { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? RoleId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime? CreateTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string CreateUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public DateTime? ModifyTime { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public string ModifyUser { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public bool? IsDel { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public int? Sort { get; set; }
	}
	/// <summary>
	/// 
	/// </summary>    
	[TableName("dbo.adUserAndRole")]
	[PrimaryKey("Id")]
	[ExplicitColumns]
    public partial class adUserAndRole : PetaPocoAdouDB.Record<adUserAndRole>  
    {
		/// <summary>
		/// 
		/// </summary>
		[Column] public long Id { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? RoleId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Column] public long? UserId { get; set; }
	}
}
