package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj03MediaMng;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 媒体費管理DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj03MediaMngDAO extends AbstractSimpleRdbDao {

//    /** 検索条件 */
//    private Tbj03MediaMngCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj03MediaMngDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj03MediaMng.MEDIAMNGNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj03MediaMng.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj03MediaMng.CRTDATE
                ,Tbj03MediaMng.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj03MediaMng.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj03MediaMng.MEDIAMNGNO
                ,Tbj03MediaMng.PHASE
                ,Tbj03MediaMng.MDYEAR
                ,Tbj03MediaMng.MDMONTH
                ,Tbj03MediaMng.DCARCD
                ,Tbj03MediaMng.MEDIACD
                ,Tbj03MediaMng.HMCOSTTOTAL
                ,Tbj03MediaMng.CRTDATE
                ,Tbj03MediaMng.CRTNM
                ,Tbj03MediaMng.CRTAPL
                ,Tbj03MediaMng.CRTID
                ,Tbj03MediaMng.UPDDATE
                ,Tbj03MediaMng.UPDNM
                ,Tbj03MediaMng.UPDAPL
                ,Tbj03MediaMng.UPDID
        };
    }

}
