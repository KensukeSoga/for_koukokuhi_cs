using System.Text;
using System.Data;
namespace Isid.KKH.Common.KKHSchema
{

    /// <summary>
    /// 条件データセット 
    /// </summary>
    /// <remarks>
    ///   修正管理 
    ///   <list type="table">
    ///     <listheader>
    ///       <description>日付</description>
    ///       <description>修正者</description>
    ///       <description>内容</description>
    ///     </listheader>
    ///     <item>
    ///       <description>2011/01/19</description>
    ///       <description>ISID-IT Y.Sanuki</description>
    ///       <description>新規作成</description>
    ///     </item>
    ///   </list>
    /// </remarks>
    partial class Condition
    {
        #region メンバ


        /// <summary>
        /// ALLのカテゴリーコード 
        /// </summary>
        public const string CATEGORY_CODE_ALL = "00";

        /// <summary>
        /// ALLのカテゴリー名 
        /// </summary>
        public const string CATEGORY_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのブランド名 
        /// </summary>
        public const string BRAND_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのサブブランド名 
        /// </summary>
        public const string SUB_BRAND_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのコピー名 
        /// </summary>
        public const string COPY_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのカンパニー名 
        /// </summary>
        public const string COMPANY_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのイニシアチブ名 
        /// </summary>
        public const string INITIATIVE_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのコレクション名 
        /// </summary>
        public const string COLLECTION_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLのターゲットコード 
        /// </summary>
        public const string TARGET_CODE_ALL = "ZZ";

        /// <summary>
        /// ALLのターゲット名 
        /// </summary>
        public const string TARGET_NAME_ALL = "ＡＬＬ";

        /// <summary>
        /// ALLの並び順 
        /// </summary>
        public const int ORDER_NO_ALL = -1;

        #endregion メンバ
        #region パブリックメソッド

        /// <summary>
        /// All行データを追加します。 
        /// </summary>
        public void AddAllRowByDataRead()
        {
            // Category
            this.Category.AddCategoryRowByAll();
            // Brand
            this.Brand.AddBrandRowByAll();
            // Sub Brand
            this.SubBrand.AddSubBrandRowByAll();
            // Copy
            this.Copy.AddCopyRowByAll();
        }

        /// <summary>
        /// All行データを追加します。 
        /// </summary>
        public void AddAllRowByRgBrand()
        {
            // Brand
            this.Brand.AddBrandRowByAll();
            // Sub Brand
            this.SubBrand.AddSubBrandRowByAll();
            // Copy
            this.Copy.AddCopyRowByAll();

            // Company
            this.Company.AddCompanyRowByAll();
            // Initiative
            this.Initiative.AddInitiativeRowByAll();

            // Collection Name
            this.Collection.AddCollectionRowByAll();
            // Target
            this.Target.AddTargetRowByAll();
        }

        /// <summary>
        /// All行データを追加します。 
        /// </summary>
        public void AddAllRowByCompetitors()
        {
            // Company
            this.Company.AddCompanyRowByAll();
            // Initiative
            this.Initiative.AddInitiativeRowByAll();
        }

        #endregion パブリックメソッド

        #region カテゴリーデータテーブル

        /// <summary>
        /// カテゴリーデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/01/19</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class CategoryDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// All行データを追加します。 
            /// </summary>
            public void AddCategoryRowByAll()
            {
                CategoryRow drCategory = this.NewCategoryRow();
                drCategory.BeginEdit();
                drCategory.CategoryCode = CATEGORY_CODE_ALL;
                drCategory.CategoryName = CATEGORY_NAME_ALL;
                drCategory.OrderNo = ORDER_NO_ALL;
                drCategory.EndEdit();
                this.AddCategoryRow(drCategory);
            }

            #endregion パブリックメソッド
        }

        #endregion カテゴリーデータテーブル

        #region ブランドデータテーブル

        /// <summary>
        /// ブランドデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/01/19</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class BrandDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddBrandRowByAll()
            {
                BrandRow drBrand = this.NewBrandRow();
                drBrand.BeginEdit();
                drBrand.CategoryCode = CATEGORY_CODE_ALL;
                drBrand.BrandName = BRAND_NAME_ALL;
                drBrand.OrderNo = ORDER_NO_ALL;
                drBrand.EndEdit();
                this.AddBrandRow(drBrand);
            }

            #endregion パブリックメソッド
        }

        #endregion ブランドデータテーブル

        #region サブブランドデータテーブル

        /// <summary>
        /// サブブランドデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/01/19</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class SubBrandDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddSubBrandRowByAll()
            {
                SubBrandRow drSubBrand = this.NewSubBrandRow();
                drSubBrand.BeginEdit();
                drSubBrand.CategoryCode = CATEGORY_CODE_ALL;
                drSubBrand.BrandName = BRAND_NAME_ALL;
                drSubBrand.SubBrandName = SUB_BRAND_NAME_ALL;
                drSubBrand.OrderNo = ORDER_NO_ALL;
                drSubBrand.EndEdit();
                this.AddSubBrandRow(drSubBrand);
            }

            #endregion パブリックメソッド
        }

        #endregion サブブランドデータテーブル

        #region コピーデータテーブル

        /// <summary>
        /// コピーデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/01/19</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class CopyDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddCopyRowByAll()
            {
                CopyRow drCopy = this.NewCopyRow();
                drCopy.BeginEdit();
                drCopy.CategoryCode = CATEGORY_CODE_ALL;
                drCopy.BrandName = BRAND_NAME_ALL;
                drCopy.SubBrandName = SUB_BRAND_NAME_ALL;
                drCopy.CopyName = COPY_NAME_ALL;
                drCopy.OrderNo = ORDER_NO_ALL;
                drCopy.EndEdit();
                this.AddCopyRow(drCopy);
            }

            #endregion パブリックメソッド
        }

        #endregion コピーデータテーブル

        #region カンパニーデータテーブル

        /// <summary>
        /// カンパニーデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/02/08</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class CompanyDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddCompanyRowByAll()
            {
                CompanyRow drCompany = this.NewCompanyRow();
                drCompany.BeginEdit();
                drCompany.CategoryCode = CATEGORY_CODE_ALL;
                drCompany.CompanyName = COMPANY_NAME_ALL;
                drCompany.OrderNo = ORDER_NO_ALL;
                drCompany.EndEdit();
                this.AddCompanyRow(drCompany);
            }

            #endregion パブリックメソッド
        }

        #endregion カンパニーデータテーブル

        #region イニシアチブデータテーブル

        /// <summary>
        /// イニシアチブデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/02/08</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class InitiativeDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddInitiativeRowByAll()
            {
                InitiativeRow drInitiative = this.NewInitiativeRow();
                drInitiative.BeginEdit();
                drInitiative.CategoryCode = CATEGORY_CODE_ALL;
                drInitiative.CompanyName = COMPANY_NAME_ALL;
                drInitiative.InitiativeName = INITIATIVE_NAME_ALL;
                drInitiative.OrderNo = ORDER_NO_ALL;
                drInitiative.EndEdit();
                this.AddInitiativeRow(drInitiative);
            }

            #endregion パブリックメソッド
        }

        #endregion イニシアチブデータテーブル

        #region コレクションデータテーブル

        /// <summary>
        /// コレクションデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/02/08</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class CollectionDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddCollectionRowByAll()
            {
                CollectionRow drCollection = this.NewCollectionRow();
                drCollection.BeginEdit();
                drCollection.SaveName = COLLECTION_NAME_ALL;
                drCollection.OrderNo = ORDER_NO_ALL;
                drCollection.EndEdit();
                this.AddCollectionRow(drCollection);
            }

            #endregion パブリックメソッド
        }

        #endregion コレクションデータテーブル

        #region ターゲットデータテーブル

        /// <summary>
        /// ターゲットデータテーブル 
        /// </summary>
        /// <remarks>
        ///   修正管理 
        ///   <list type="table">
        ///     <listheader>
        ///       <description>日付</description>
        ///       <description>修正者</description>
        ///       <description>内容</description>
        ///     </listheader>
        ///     <item>
        ///       <description>2011/02/08</description>
        ///       <description>ISID-IT Y.Sanuki</description>
        ///       <description>新規作成</description>
        ///     </item>
        ///   </list>
        /// </remarks>
        partial class TargetDataTable
        {
            #region パブリックメソッド

            /// <summary>
            /// ALL行データを追加します。 
            /// </summary>
            public void AddTargetRowByAll()
            {
                TargetRow drTarget = this.NewTargetRow();
                drTarget.BeginEdit();
                drTarget.TargetCode = TARGET_CODE_ALL;
                drTarget.TargetName = TARGET_NAME_ALL;
                drTarget.OrderNo = ORDER_NO_ALL;
                drTarget.EndEdit();
                this.AddTargetRow(drTarget);
            }

            #endregion パブリックメソッド
        }

        #endregion ターゲットデータテーブル

    }
}
