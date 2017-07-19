package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * HC商品選択取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/2/26 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindHCItemSelectionDAO extends AbstractRdbDao {

    private FindHCItemSelectionCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindHCItemSelectionDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[]{
                "ROW_NUMBER() OVER (ORDER BY DETAILCNT DESC) NUM",
                "DETAILCNT",
                Mbj08HcProduct.MEDIACLASSCD,
                Mbj08HcProduct.MEDIACLASSNM,
                Mbj08HcProduct.MEDIACD,
                Mbj08HcProduct.MEDIANM,
                Mbj08HcProduct.BUSINESSCLASSCD,
                Mbj08HcProduct.BUSINESSCLASSNM,
                Mbj08HcProduct.BUSINESSCD,
                Mbj08HcProduct.BUSINESSNM,
                Mbj08HcProduct.PRODUCTCD,
                Mbj08HcProduct.PRODUCTNM,
                Tbj06EstimateDetail.PRODUCTNM,
                Tbj06EstimateDetail.PRODUCTNMSUB,
                Tbj06EstimateDetail.UPDID
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        StringBuffer tbl = new StringBuffer();

        tbl.append("(");
        tbl.append(getHcProduct());
        tbl.append(") HCPRODUCT ");
        tbl.append(", ");
        tbl.append("(");
        tbl.append(getEstimateDetail());
        tbl.append(") ESTIMATEDETAIL ");

        return tbl.toString();
    }

    /**
     * HC商品マスタを取得する
     *
     * @return String HC商品マスタ
     */
    private String getHcProduct() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT DISTINCT ");
        sql.append(Mbj08HcProduct.MEDIACLASSCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.MEDIACLASSNM);
        sql.append(", ");
        sql.append(Mbj08HcProduct.MEDIACD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.MEDIANM);
        sql.append(", ");
        sql.append(Mbj08HcProduct.BUSINESSCLASSCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.BUSINESSCLASSNM);
        sql.append(", ");
        sql.append(Mbj08HcProduct.BUSINESSCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.BUSINESSNM);
        sql.append(", ");
        sql.append(Mbj08HcProduct.PRODUCTCD);
        sql.append(", ");
        sql.append(Mbj08HcProduct.PRODUCTNM);

        sql.append(" FROM ");
        sql.append(Mbj08HcProduct.TBNAME);

        sql.append(" WHERE ");
        sql.append(Mbj08HcProduct.USEBUMONCD);
        sql.append(" = '");
        sql.append(_condition.getUsebumoncd());
        sql.append("'");

        return sql.toString();
    }

    /**
     * 見積明細を取得する
     *
     * @return String 見積明細
     */
    public String getEstimateDetail() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("COUNT(*) DETAILCNT");
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.MEDIACLASSCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.MEDIACD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.BUSINESSCLASSCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.BUSINESSCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.PRODUCTCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.PRODUCTNM);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.PRODUCTNMSUB);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.UPDID);

        sql.append(" FROM ");
        sql.append(Tbj05EstimateItem.TBNAME);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.TBNAME);

        sql.append(" WHERE ");
        sql.append(Tbj05EstimateItem.PHASE);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.PHASE);
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.CRDATE);
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.ESTSEQNO);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.ESTSEQNO);
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.HCBUMONCD);
        sql.append(" IN ");
        sql.append("(");
        sql.append(getHCBumonCd());
        sql.append(")");

        if (_condition.getEstimatenm() != null && !_condition.getEstimatenm().isEmpty()) {
            sql.append(" AND ");
            sql.append(Tbj05EstimateItem.ESTIMATENM);
            sql.append(" LIKE ");
            sql.append("'%");
            sql.append(_condition.getEstimatenm());
            sql.append("%'");
        }

        if (_condition.getProductcd() != null && !_condition.getProductcd().isEmpty()) {
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.PRODUCTCD);
            sql.append(" LIKE ");
            sql.append("'%");
            sql.append(_condition.getProductcd());
            sql.append("%'");
        }

        if (_condition.getProductnm() != null && !_condition.getProductnm().isEmpty()) {
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.PRODUCTNM);
            sql.append(" LIKE ");
            sql.append("'%");
            sql.append(_condition.getProductnm());
            sql.append("%'");
        }

        if (_condition.getProductnmsub() != null && !_condition.getProductnmsub().isEmpty()) {
            sql.append(" AND ");
            sql.append(Tbj06EstimateDetail.PRODUCTNMSUB);
            sql.append(" LIKE ");
            sql.append("'%");
            sql.append(_condition.getProductnmsub());
            sql.append("%'");
        }

        sql.append(" GROUP BY ");
        sql.append(Tbj06EstimateDetail.MEDIACLASSCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.MEDIACD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.BUSINESSCLASSCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.BUSINESSCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.PRODUCTCD);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.PRODUCTNM);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.PRODUCTNMSUB);
        sql.append(", ");
        sql.append(Tbj06EstimateDetail.UPDID);

        return sql.toString();
    }

    /**
     * HC商品コードを取得する
     *
     * @return String HC商品コード
     */
    private String getHCBumonCd() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(Mbj06HcBumon.HCBUMONCD);
        sql.append(" FROM ");
        sql.append(Mbj06HcBumon.TBNAME);
        sql.append(" WHERE ");
        sql.append(Mbj06HcBumon.USEBUMONCD);
        sql.append(" IN ");
        sql.append("(");
        sql.append(getUserBumonCd());
        sql.append(")");

        return sql.toString();
    }

    /**
     * 使用部門コードを取得する
     *
     * @return String 使用部門コード
     */
    private String getUserBumonCd() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(Mbj06HcBumon.USEBUMONCD);
        sql.append(" FROM ");
        sql.append(Mbj06HcBumon.TBNAME);
        sql.append(" WHERE ");
        sql.append(Mbj06HcBumon.HCBUMONCD);
        sql.append(" = '");
        sql.append(_condition.getHcbumoncd());
        sql.append("'");

        return sql.toString();
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(", ");
            }
        }

        sql.append(" FROM ");
        sql.append(getTableName());

        sql.append(" WHERE ");
        sql.append(Mbj08HcProduct.MEDIACLASSCD);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.MEDIACLASSCD);
        sql.append(" AND ");
        sql.append(Mbj08HcProduct.MEDIACD);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.MEDIACD);
        sql.append(" AND ");
        sql.append(Mbj08HcProduct.BUSINESSCLASSCD);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.BUSINESSCLASSCD);
        sql.append(" AND ");
        sql.append(Mbj08HcProduct.BUSINESSCD);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.BUSINESSCD);
        sql.append(" AND ");
        sql.append(Mbj08HcProduct.PRODUCTCD);
        sql.append(" = ");
        sql.append(Tbj06EstimateDetail.PRODUCTCD);

        sql.append(" ORDER BY ");
        sql.append("DETAILCNT DESC");

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindHCItemSelectionVO> selectVO(FindHCItemSelectionCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindHCItemSelectionVO());
        try
        {
            _condition = condition;
            return (List<FindHCItemSelectionVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
