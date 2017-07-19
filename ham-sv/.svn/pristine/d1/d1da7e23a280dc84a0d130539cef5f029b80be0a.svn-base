package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj06HcBumon;
import jp.co.isid.ham.integ.tbl.Mbj08HcProduct;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj17CrDivision;
import jp.co.isid.ham.integ.tbl.Mbj26BillGroup;
import jp.co.isid.ham.integ.tbl.Tbj05EstimateItem;
import jp.co.isid.ham.integ.tbl.Tbj06EstimateDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;

/**
 * <P>
 * 見積案件/見積明細取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/11 T.Fujiyoshi)<BR>
 * ・HDX対応(2016/04/13 HLC K.Oki)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class FindEstItemDtlDAO extends AbstractRdbDao {

    FindEstItemDtlCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindEstItemDtlDAO() {
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
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj05EstimateItem.PHASE
                ,Tbj05EstimateItem.CRDATE
                ,Tbj05EstimateItem.ESTSEQNO
                ,Tbj05EstimateItem.ESTIMATECLASS
                ,Tbj05EstimateItem.ESTIMATEDATE
                ,Tbj05EstimateItem.COOPKBN
                ,Tbj05EstimateItem.ADDRESS
                ,Tbj05EstimateItem.ESTIMATENM
                ,Tbj05EstimateItem.HCBUMONCD
                ,Tbj05EstimateItem.HCUSERNM
                ,Tbj05EstimateItem.DLVDATE
                ,Tbj05EstimateItem.DISCOUNTRATE
                ,Tbj05EstimateItem.BIKO
                ,Tbj05EstimateItem.LASTOUTPUTDATE
                ,Tbj05EstimateItem.LASTOUTPUTNM
                ,Tbj05EstimateItem.OUTPUTFILENM
                ,Tbj05EstimateItem.DCARCD
                ,Tbj05EstimateItem.DIVCD
                ,Tbj05EstimateItem.GROUPCD
                ,Tbj05EstimateItem.CRTDATE
                ,Tbj05EstimateItem.CRTNM
                ,Tbj05EstimateItem.CRTAPL
                ,Tbj05EstimateItem.CRTID
                ,Tbj05EstimateItem.UPDDATE
                ,Tbj05EstimateItem.UPDNM
                ,Tbj05EstimateItem.UPDAPL
                ,Tbj05EstimateItem.UPDID
                ,Mbj05Car.CARNM
                ,Mbj17CrDivision.DIVNM
                ,Mbj26BillGroup.GROUPNM
                ,Mbj12Code.CODENAME
                ,Mbj06HcBumon.HCBUMONNM
                ,Mbj06HcBumon.POSTNO
                ,Mbj06HcBumon.ADDRESS1
                ,Mbj06HcBumon.ADDRESS2
                ,Mbj06HcBumon.BUMONCORPNM
                ,Tbj06EstimateDetail.ESTDETAILSEQNO
                ,Tbj06EstimateDetail.PHASE
                ,Tbj06EstimateDetail.CRDATE
                ,Tbj06EstimateDetail.ESTSEQNO
                ,Tbj06EstimateDetail.SORTNO
                ,Tbj06EstimateDetail.PRODUCTCD
                ,Tbj06EstimateDetail.PRODUCTNM
                ,Tbj06EstimateDetail.PRODUCTNMSUB
                ,Tbj06EstimateDetail.MEDIACLASSCD
                ,Tbj06EstimateDetail.MEDIACD
                ,Tbj06EstimateDetail.BUSINESSCLASSCD
                ,Tbj06EstimateDetail.BUSINESSCD
                ,Tbj06EstimateDetail.TEKIYOU
                ,Tbj06EstimateDetail.OPERATIONDATE
                ,Tbj06EstimateDetail.SIZECD
                ,Tbj06EstimateDetail.SIZE
                ,Tbj06EstimateDetail.SUURYOU
                ,Tbj06EstimateDetail.UNITGROUPCD
                ,Tbj06EstimateDetail.UNITGROUPNM
                ,Tbj06EstimateDetail.TANKA
                ,Tbj06EstimateDetail.HYOUJUN
                ,Tbj06EstimateDetail.NEBIKI
                ,Tbj06EstimateDetail.MITUMORI
                ,Tbj06EstimateDetail.KAZEI
                ,Tbj06EstimateDetail.SYOUHIZEI
                ,Tbj06EstimateDetail.GOUKEI
                ,Tbj06EstimateDetail.CALKBN
                ,Tbj06EstimateDetail.NOUNYUUFLG
                ,Tbj06EstimateDetail.DEKIDAKAFLG
                ,Tbj06EstimateDetail.OUTPUTGROUP
                /* 2016/04/13 HDX対応 HLC K.Oki ADD Start */
                ,Tbj06EstimateDetail.HCBUMONCDBILL
                /* 2016/04/13 HDX対応 HLC K.Oki ADD End */
                ,Mbj08HcProduct.MEDIACLASSNM
                ,Mbj08HcProduct.MEDIANM
                ,Mbj08HcProduct.BUSINESSCLASSNM
                ,Mbj08HcProduct.BUSINESSNM
                ,Mbj08HcProduct.PRODUCTNM
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

        tbl.append(Tbj05EstimateItem.TBNAME);
        tbl.append(", ");
        tbl.append(Tbj06EstimateDetail.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj05Car.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj17CrDivision.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj26BillGroup.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj06HcBumon.TBNAME);
        tbl.append(", ");
        tbl.append(Mbj08HcProduct.TBNAME);
        tbl.append(", ");
        tbl.append("(");
        tbl.append(getCoopKbn());
        tbl.append(") COOPKBN");

        return tbl.toString();
    }

    /**
     * コープ区分を取得する
     *
     * @return String コープ区分
     */
    private String getCoopKbn() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append(Mbj12Code.KEYCODE);
        sql.append(", ");
        sql.append(Mbj12Code.CODENAME);
        sql.append(" FROM ");
        sql.append(Mbj12Code.TBNAME);
        sql.append(" WHERE ");
        sql.append(Mbj12Code.CODETYPE);
        sql.append(" = ");
        sql.append("'07'");

        return sql.toString();
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
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

        sql.append("SELECT DISTINCT ");
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
        sql.append(Tbj05EstimateItem.PHASE);
        sql.append(" = ");
        sql.append(_condition.getPhase());
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.CRDATE);
        sql.append(" = ");
        sql.append("TO_DATE('");
        sql.append(_condition.getYearMonth());
        sql.append("', 'YYYY/MM')");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.ESTIMATECLASS);
        sql.append(" = ");
        sql.append("'");
        sql.append(_condition.getEstimateClass());
        sql.append("'");

        sql.append(" AND ");
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
        sql.append(Tbj05EstimateItem.DCARCD);
        sql.append(" = ");
        sql.append(Mbj05Car.DCARCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.DIVCD);
        sql.append(" = ");
        sql.append(Mbj17CrDivision.DIVCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.GROUPCD);
        sql.append(" = ");
        sql.append(Mbj26BillGroup.GROUPCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.COOPKBN);
        sql.append(" = ");
        sql.append(Mbj12Code.KEYCODE);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj05EstimateItem.HCBUMONCD);
        sql.append(" = ");
        sql.append(Mbj06HcBumon.HCBUMONCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.PRODUCTCD);
        sql.append(" = ");
        sql.append(Mbj08HcProduct.PRODUCTCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.MEDIACLASSCD);
        sql.append(" = ");
        sql.append(Mbj08HcProduct.MEDIACLASSCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.MEDIACD);
        sql.append(" = ");
        sql.append(Mbj08HcProduct.MEDIACD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.BUSINESSCLASSCD);
        sql.append(" = ");
        sql.append(Mbj08HcProduct.BUSINESSCLASSCD);
        sql.append("(+)");
        sql.append(" AND ");
        sql.append(Tbj06EstimateDetail.BUSINESSCD);
        sql.append(" = ");
        sql.append(Mbj08HcProduct.BUSINESSCD);
        sql.append("(+)");

        sql.append(" ORDER BY ");
        sql.append(Tbj06EstimateDetail.SORTNO);

        return sql.toString();
    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param condition
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindEstItemDtlVO> selectVO(FindEstItemDtlCondition condition) throws HAMException {
        //パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindEstItemDtlVO());
        try
        {
            _condition = condition;
            return (List<FindEstItemDtlVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
