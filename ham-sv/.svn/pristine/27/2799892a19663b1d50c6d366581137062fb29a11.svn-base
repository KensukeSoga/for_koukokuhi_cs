package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Mbj38CarConvert;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 車種変換マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj38CarConvertDAO extends AbstractSimpleRdbDao {

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode{DEL};
    private ExecSqlMode _ExecSqlMode = ExecSqlMode.DEL;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj38CarConvertDAO() {
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
                Mbj38CarConvert.SOZAIYM
                ,Mbj38CarConvert.SOZAIKG
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj38CarConvert.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj38CarConvert.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj38CarConvert.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj38CarConvert.PHASE
                ,Mbj38CarConvert.SOZAIYM
                ,Mbj38CarConvert.SOZAIKG
                ,Mbj38CarConvert.DCARCD
                ,Mbj38CarConvert.UPDDATE
                ,Mbj38CarConvert.UPDNM
                ,Mbj38CarConvert.UPDAPL
                ,Mbj38CarConvert.UPDID
        };
    }

    /**
     * 実行SQLを作成する
     */
    @Override
    public String getExecString() {

        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.DEL)) {
            sql = getExecStringForDEL();
        }

        return sql.toString();
    }

    /**
     * 車種変換マスタ削除SQL文を作成する
     * @return
     */
    private String getExecStringForDEL() {

        StringBuffer sql = new StringBuffer();
        Mbj38CarConvertVO vo = (Mbj38CarConvertVO)getModel();

        sql.append(" DELETE");

        sql.append(" FROM");
        sql.append(" " + getTableName());

        sql.append(" WHERE");
        sql.append(" " + Mbj38CarConvert.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(vo.getSOZAIYM()));

        return sql.toString();
    }

    /**
     * 指定した年月のデータを全て削除する
     * @param vo
     * @throws HAMException
     */
    public void deleteByMonth(Mbj38CarConvertVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            _ExecSqlMode = ExecSqlMode.DEL;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }
}
