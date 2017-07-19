package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Mfk02Jun;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * ユニットNo.マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mfk02JunDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Mfk02JunCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Mfk02JunDAO() {
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
                Mfk02Jun.ZSBCH0100
                ,Mfk02Jun.DATETO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mfk02Jun.TIMSTMP;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mfk02Jun.TIMSTMP
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mfk02Jun.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mfk02Jun.TIMSTMP
                ,Mfk02Jun.UPDAPL
                ,Mfk02Jun.UPDTNT
                ,Mfk02Jun.ZSBCH0100
                ,Mfk02Jun.DATETO
                ,Mfk02Jun.DATEFROM
                ,Mfk02Jun.ZSBCH0124
                ,Mfk02Jun.ZSBCH0102
                ,Mfk02Jun.ZSBCH0103
                ,Mfk02Jun.ZSBCH0104
                ,Mfk02Jun.ZSBCH0101
                ,Mfk02Jun.ZSBCH0105
                ,Mfk02Jun.ZSBCH0125
                ,Mfk02Jun.ZSBCH0109
                ,Mfk02Jun.ZSBCH0112
                ,Mfk02Jun.ZSBCH0111
                ,Mfk02Jun.ZSBCH0119
                ,Mfk02Jun.ZSBCH0113
                ,Mfk02Jun.ZSBCH0120
                ,Mfk02Jun.ZSBCH0114
                ,Mfk02Jun.ZSBCH0115
                ,Mfk02Jun.ZSBCH0116
                ,Mfk02Jun.ZSBCH0123
                ,Mfk02Jun.ZSBCH0118
                ,Mfk02Jun.ZSBCH0211
                ,Mfk02Jun.ZSBCH0212
                ,Mfk02Jun.ZSBCH0255
                ,Mfk02Jun.ZSBCH0253
                ,Mfk02Jun.ZSBCH0254
                ,Mfk02Jun.ZSBCH0201
                ,Mfk02Jun.ZSBCH0202
                ,Mfk02Jun.ZSBCH0203
                ,Mfk02Jun.ZSBCH0204
                ,Mfk02Jun.ZSBCH0205
                ,Mfk02Jun.ZSBCH0233
                ,Mfk02Jun.ZSBCH0234
                ,Mfk02Jun.ZSBCH0235
                ,Mfk02Jun.ZSBCH0236
                ,Mfk02Jun.ZSBCH0237
                ,Mfk02Jun.ZSBCH0316
                ,Mfk02Jun.ZSBCH0317
                ,Mfk02Jun.TEXTLONG
                ,Mfk02Jun.TEXTMIDDLE
                ,Mfk02Jun.NAIYOSTSU
        };
    }

}
