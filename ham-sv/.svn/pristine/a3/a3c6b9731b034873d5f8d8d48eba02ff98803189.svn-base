package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * コンテンツDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj17ContentDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Tbj17ContentCondition _condition = null;

    /** getExecSQLで発行するSQLのモード() */
    private enum ExecSqlMode{DEL, };
    private ExecSqlMode _ExecSqlMode = ExecSqlMode.DEL;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj17ContentDAO() {
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
                Tbj17Content.CMCD
                ,Tbj17Content.CTRTKBN
                ,Tbj17Content.CTRTNO
                ,Tbj17Content.CRTDATE
                ,Tbj17Content.CRTNM
                ,Tbj17Content.CRTAPL
                ,Tbj17Content.CRTID
                ,Tbj17Content.UPDDATE
                ,Tbj17Content.UPDNM
                ,Tbj17Content.UPDAPL
                ,Tbj17Content.UPDID
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj17Content.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj17Content.CRTDATE
                ,Tbj17Content.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj17Content.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj17Content.CMCD
                ,Tbj17Content.CTRTKBN
                ,Tbj17Content.CTRTNO
                ,Tbj17Content.CRTDATE
                ,Tbj17Content.CRTNM
                ,Tbj17Content.CRTAPL
                ,Tbj17Content.CRTID
                ,Tbj17Content.UPDDATE
                ,Tbj17Content.UPDNM
                ,Tbj17Content.UPDAPL
                ,Tbj17Content.UPDID
        };
    }


    /**
     *デフォルトのSQL文を返します
     * @return
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();
        sql.append(" SELECT ");
        for (int i = 0; i < getTableColumnNames().length; i++) {
            sql.append((i != 0 ? " ," : " "));
            sql.append("" + getTableColumnNames()[i] + " ");
        }
        sql.append(" FROM ");
        sql.append(" " + getTableName() + " ");

        return sql.toString();
    }


    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj17ContentVO loadVO(Tbj17ContentVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj17ContentVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public void insertVO(Tbj17ContentVO vo) throws HAMException {
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

    /**
     * PK更新
     * @param vo
     * @return
     * @throws HAMException
     */
    public void updateVO(Tbj17ContentVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            super.update();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * PK削除
     * @param vo
     * @return
     * @throws HAMException
     */
    public void deleteVO(Tbj17ContentVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            super.remove();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    @Override
    public String getExecString() {
        String sql = "";

        if (_ExecSqlMode.equals(ExecSqlMode.DEL)) {
            sql = getExecStringForDEL();
        }

        return sql.toString();
    }

    /**
     * 削除SQLを取得する
     * @return
     */
    private String getExecStringForDEL() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append("     " + getTableName() + " ");
        //WHERE句-------------------------------------------------------------------------------------------------------
        sql.append(generateWhereByCond(getModel()));

        return sql.toString();
    }

    /**
     * 値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

    private String ConvertToDBString(Object obj) {
        return super.getDBModelInterface().ConvertToDBString(obj);
    }

    /**
     * VOの内容で削除する
     * @param vo
     * @param cond
     * @throws HAMException
     */
    public void deleteByVo(Tbj17ContentVO vo) throws HAMException {

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
