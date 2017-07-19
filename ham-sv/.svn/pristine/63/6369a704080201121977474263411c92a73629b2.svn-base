package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea10Irsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMea11DisplayIrsk;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu07SikKrSprd;
import jp.co.isid.ham.integ.tbl.RepaVbjaMeu29Cc;
import jp.co.isid.ham.integ.tbl.Tbj35Knr;
import jp.co.isid.ham.integ.tbl.VbjChargeGrpMedia;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 依頼先取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/10/01 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class FindContactRequestNarrowingDAO extends AbstractSimpleRdbDao {

    FindContactRequestNarrowingCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public FindContactRequestNarrowingDAO() {
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
        return null;
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
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
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT ");
        sql.append("   DECODE(" + RepaVbjaMea11DisplayIrsk.JYUCTYPE + ", '" + _condition.getJYUCTYPE() + "', " + RepaVbjaMea10Irsk.IRSKCD + " || " + RepaVbjaMea10Irsk.IRSKSUBCD + ", " + RepaVbjaMea10Irsk.IRSKCD + ") AS IRAISAKICODE,");
        sql.append("   DECODE(" + RepaVbjaMea10Irsk.ALASUSEFLG + ", '" + _condition.getALASUSEFLG() + "', " + RepaVbjaMea10Irsk.IRSKALASHYOJIKJ + ", " + RepaVbjaMeu07SikKrSprd.HYOJIKJ + ") AS IRAISAKINAME,");
        sql.append(    RepaVbjaMea11DisplayIrsk.DSIKKBNCD              + " AS DSIKKBNCD,");
        sql.append(    RepaVbjaMea11DisplayIrsk.IRSKSHOWNO             + " AS IRSKSHOWNO,");
        sql.append(    VbjChargeGrpMedia.VOP_BJ_BTAICD + " || " + VbjChargeGrpMedia.VOP_BJ_KBANCD + " AS MEDIASCD,");
        sql.append(getSortNoSQL());

        sql.append(" FROM ");
        sql.append(    RepaVbjaMea10Irsk.TBNAME + ", ");
        sql.append(    RepaVbjaMea11DisplayIrsk.TBNAME  + ", ");
        sql.append(    RepaVbjaMeu07SikKrSprd.TBNAME + ", ");
        sql.append(    Tbj35Knr.TBNAME + ", ");
        sql.append(    VbjChargeGrpMedia.TBNAME + ", ");
        sql.append(    RepaVbjaMeu29Cc.TBNAME + ", ");
        sql.append(    Mbj12Code.TBNAME);

        sql.append(" WHERE ");
        sql.append("     " + VbjChargeGrpMedia.VOP_BJ_EGSYOCD + " = '" + _condition.getATSEGSYOCD() + "'");
        sql.append(" AND " + VbjChargeGrpMedia.VOP_BJ_TNTGRP + " = SUBSTR(" + RepaVbjaMeu29Cc.KYCD + ", 1, 2)");
        sql.append(" AND " + RepaVbjaMeu29Cc.HKYMD + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMeu29Cc.HAISYMD + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + Mbj12Code.CODETYPE + " = '" + _condition.getCODETYPEEGSYOCD() + "'");
        sql.append(" AND " + Mbj12Code.KEYCODE + " = " + VbjChargeGrpMedia.VOP_BJ_EGSYOCD);
        sql.append(" AND " + RepaVbjaMeu29Cc.KYCDKND + " = " + Mbj12Code.YOBI1);
        sql.append(" AND " + RepaVbjaMeu29Cc.YOBI1 + " LIKE '1%'");
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKCD + " = SUBSTR(" + RepaVbjaMeu29Cc.YOBI1 + ", 2)");
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD + " = " + VbjChargeGrpMedia.VOP_BJ_TNTGRP );

        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.ATSEGSYOCD  + " = '" + _condition.getATSEGSYOCD() + "'");
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.JYUCTYPE    + " = '" + _condition.getJYUCTYPE() + "'" );
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKCD      + " = "  + RepaVbjaMea10Irsk.IRSKCD);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKSUBCD   + " = "  + RepaVbjaMea10Irsk.IRSKSUBCD);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.IRSKCD      + " = "  + RepaVbjaMeu07SikKrSprd.SIKCD);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.JYUCFLG     + " = "  + "'" + _condition.getJYUCFLG() + "'" );
        sql.append(" AND " + RepaVbjaMea10Irsk.HKYMD              + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMea10Irsk.HAISYMD            + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.HKYMD       + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMea11DisplayIrsk.HAISYMD     + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.SIKCDKYK      + " <= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + RepaVbjaMeu07SikKrSprd.ENDYMD        + " >= " + Tbj35Knr.EIGYOBI);
        sql.append(" AND " + Tbj35Knr.SYSTEMNO + " = '02'");

        sql.append(" GROUP BY " );
        sql.append(VbjChargeGrpMedia.VOP_BJ_BTAICD + ", ");
        sql.append(VbjChargeGrpMedia.VOP_BJ_KBANCD + ", ");
        sql.append(RepaVbjaMea11DisplayIrsk.JYUCTYPE + ", ");
        sql.append(RepaVbjaMea10Irsk.IRSKCD + ", ");
        sql.append(RepaVbjaMea10Irsk.IRSKSUBCD + ", ");
        sql.append(RepaVbjaMea10Irsk.ALASUSEFLG + ", ");
        sql.append(RepaVbjaMea10Irsk.IRSKALASHYOJIKJ + ", ");
        sql.append(RepaVbjaMeu07SikKrSprd.HYOJIKJ + ", ");
        sql.append(RepaVbjaMea11DisplayIrsk.DSIKKBNCD + ", ");
        sql.append(RepaVbjaMea11DisplayIrsk.IRSKSHOWNO);

        return sql.toString();
    }

    /**
     * SORT NOのSQL文を返す
     * @return SORT NOのSQL文
     */
    private String getSortNoSQL()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" ROW_NUMBER() OVER (");
        sql.append(" PARTITION BY ");
        sql.append(VbjChargeGrpMedia.VOP_BJ_BTAICD );
        sql.append(", ");
        sql.append(VbjChargeGrpMedia.VOP_BJ_KBANCD );
        sql.append(" ORDER BY ");
        sql.append(RepaVbjaMea10Irsk.IRSKSUBCD);
        sql.append(")");
        sql.append(" AS SORTNO");

        return sql.toString();
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindContactRequestNarrowingVO> selectVO(FindContactRequestNarrowingCondition condition) throws HAMException {
        // パラメータチェック
        if (condition == null)
        {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new FindContactRequestNarrowingVO());
        _condition = condition;

        try
        {
            return super.find();
        }
        catch (UserException e)
        {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
