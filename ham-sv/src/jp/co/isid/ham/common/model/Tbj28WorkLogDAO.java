package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj28WorkLog;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 稼働ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj28WorkLogDAO extends AbstractSimpleRdbDao {

//    /** 検索条件 */
//    private Tbj28WorkLogCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj28WorkLogDAO() {
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
        return null;
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj28WorkLog.CRTDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj28WorkLog.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj28WorkLog.CRTDATE
                ,Tbj28WorkLog.HAMID
                ,Tbj28WorkLog.HAMNM
                ,Tbj28WorkLog.SIKCDHONB
                ,Tbj28WorkLog.SIKNMHONB
                ,Tbj28WorkLog.SIKCDKYK
                ,Tbj28WorkLog.SIKNMKYK
                ,Tbj28WorkLog.SIKCDSITU
                ,Tbj28WorkLog.SIKNMSITU
                ,Tbj28WorkLog.SIKCDBU
                ,Tbj28WorkLog.SIKNMBU
                ,Tbj28WorkLog.SIKCDKA
                ,Tbj28WorkLog.SIKNMKA
                ,Tbj28WorkLog.FORMID
                ,Tbj28WorkLog.FORMNM
                ,Tbj28WorkLog.KNOID
                ,Tbj28WorkLog.KNONM
                ,Tbj28WorkLog.DSMID
                ,Tbj28WorkLog.DSMNM
        };
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Tbj28WorkLogVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            super.insert();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
