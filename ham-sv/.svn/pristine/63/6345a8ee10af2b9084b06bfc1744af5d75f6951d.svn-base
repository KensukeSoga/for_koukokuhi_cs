package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Mfk01Kkh;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 公開範囲マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mfk01KkhDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Mfk01KkhCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mfk01KkhDAO() {
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
                Mfk01Kkh.ZSBCH0100
                ,Mfk01Kkh.DATETO
                ,Mfk01Kkh.DATEFROM
                ,Mfk01Kkh.ZSBCH0105
                ,Mfk01Kkh.ZHANNIGF
                ,Mfk01Kkh.ZSBCH0109
                ,Mfk01Kkh.ZTOUKYU
                ,Mfk01Kkh.ZSBCH0110
                ,Mfk01Kkh.ZBACCTL
                ,Mfk01Kkh.ZBACCTM
                ,Mfk01Kkh.ZBACCTS
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mfk01Kkh.TIMSTMP;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mfk01Kkh.TIMSTMP
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mfk01Kkh.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mfk01Kkh.TIMSTMP
                ,Mfk01Kkh.UPDAPL
                ,Mfk01Kkh.UPDTNT
                ,Mfk01Kkh.ZSBCH0100
                ,Mfk01Kkh.DATETO
                ,Mfk01Kkh.DATEFROM
                ,Mfk01Kkh.ZSBCH0105
                ,Mfk01Kkh.ZHANNIGF
                ,Mfk01Kkh.ZSBCH0109
                ,Mfk01Kkh.ZTOUKYU
                ,Mfk01Kkh.ZSBCH0110
                ,Mfk01Kkh.ZBACCTL
                ,Mfk01Kkh.ZBACCTM
                ,Mfk01Kkh.ZBACCTS
                ,Mfk01Kkh.ZEIGYOU
                ,Mfk01Kkh.ZTRSFG
                ,Mfk01Kkh.ZPLFG
                ,Mfk01Kkh.ZJYUHACHU
                ,Mfk01Kkh.ZALLFG
                ,Mfk01Kkh.ZKEISYOU
                ,Mfk01Kkh.ZDELFG
                ,Mfk01Kkh.KKHTIMESTAMP
        };
    }

}
