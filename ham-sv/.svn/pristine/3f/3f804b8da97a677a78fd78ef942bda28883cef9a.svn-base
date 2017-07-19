package jp.co.isid.ham.common.model;

import java.math.BigDecimal;

import jp.co.isid.ham.integ.tbl.Mbj13CarOutCtrl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 車種出力設定マスタ登録DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/01/10 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class ExcelOutCarRegisterDAO extends AbstractSimpleRdbDao{

    /** 削除条件の帳票コード */
    private String _reportCd = null;

    /** 削除条件のフェイズ */
    private BigDecimal _phase = null;


    /**
     * デフォルトコンストラクタ
     */
    public ExcelOutCarRegisterDAO() {
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
        return Mbj13CarOutCtrl.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj13CarOutCtrl.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj13CarOutCtrl.REPORTCD
                ,Mbj13CarOutCtrl.DCARCD
                ,Mbj13CarOutCtrl.OUTPUTFLG
                ,Mbj13CarOutCtrl.SORTNO
                ,Mbj13CarOutCtrl.PHASE
                ,Mbj13CarOutCtrl.UPDDATE
                ,Mbj13CarOutCtrl.UPDNM
                ,Mbj13CarOutCtrl.UPDAPL
                ,Mbj13CarOutCtrl.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        return getDelCarOutCtrl();

    }

    /**
     * 対象の車種出力設定を削除します
     *
     * @return 削除SQL文
     */
    public String getDelCarOutCtrl() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Mbj13CarOutCtrl.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Mbj13CarOutCtrl.REPORTCD + " ='" + _reportCd + "' ");
        sql.append(" AND ");
        sql.append(" " + Mbj13CarOutCtrl.PHASE + " = " + _phase + " ");

        return sql.toString();
    }

    /**
     * 車種出力設定の登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insCarOutCtrl(
            Mbj13CarOutCtrlVO vo) throws HAMException {

        super.setModel(vo);
        try {
            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }

    /**
     * 車種出力設定の削除を行います
     *
     * @return
     * @throws HAMException データアクセス中にエラーが発生した場合
     */
    public void delCarOutCtrl(String reportCd,BigDecimal phase) throws HAMException {

        try {
            _reportCd = reportCd;
            _phase = phase;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

}
