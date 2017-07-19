package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.UpdateFailureException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * コードマスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj12CodeDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj12CodeCondition _condition = null;

    private enum SqlMode{SINGLE,MANY};
    private SqlMode _sqlMode = SqlMode.SINGLE;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj12CodeDAO() {
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
                Mbj12Code.CODETYPE
                ,Mbj12Code.KEYCODE
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj12Code.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj12Code.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj12Code.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj12Code.CODETYPE
                ,Mbj12Code.KEYCODE
                ,Mbj12Code.CODENAME
                ,Mbj12Code.YOBI1
                ,Mbj12Code.YOBI2
                ,Mbj12Code.YOBI3
                ,Mbj12Code.UPDDATE
                ,Mbj12Code.UPDNM
                ,Mbj12Code.UPDAPL
                ,Mbj12Code.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        String sql = "";
        if (_sqlMode.equals(SqlMode.SINGLE)) {
            sql = getSelectSQLByCondition();
        } else if (_sqlMode.equals(SqlMode.MANY)) {
            sql = getManyCd();
        }
        return sql;
    }

    /**
     * 検索SQLを取得します
     * @return
     */
    private String getManyCd() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(",");
            }
        }

        sql.append(" FROM ");
        sql.append(" " + getTableName());
        sql.append(" WHERE ");
        sql.append(" " + Mbj12Code.CODETYPE + " IN(" + _condition.getCodetype() + ") ");

        return sql.toString();
    }

    /**
     * 検索SQLを取得します
     * @return
     */
    private String getSelectSQLByCondition() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        for (int i = 0;i < getTableColumnNames().length;i++) {
            sql.append(getTableColumnNames()[i]);
            if (i < getTableColumnNames().length-1) {
                sql.append(",");
            }
        }

        sql.append(" FROM ");
        sql.append(" " + getTableName());
        sql.append(" WHERE ");
        sql.append(" " + Mbj12Code.CODETYPE + " = '" + _condition.getCodetype() + "' ");
        if (_condition.getKeycode() == null || _condition.getKeycode().trim().length() == 0) {
        } else {
            sql.append(" AND ");
            sql.append(" " + Mbj12Code.KEYCODE+ " = '" + _condition.getKeycode()+ "' ");
        }
        if (_condition.getCodename() == null || _condition.getCodename().trim().length() == 0) {
        } else {
            sql.append(" AND ");
            sql.append(" " + Mbj12Code.CODENAME+ " = '" + _condition.getCodename() + "' ");
        }

        return sql.toString();
    }

    /**
     * InsertVO
     * @param vo データ
     * @throws HAMException
     */
    public void insertVO(Mbj12CodeVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);

        try {
            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * UpdateVO
     * @param vo データ
     * @throws HAMException
     */
    public void updateVO(Mbj12CodeVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);

        try {
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * DeleteVO
     * @param vo データ
     * @throws HAMException
     */
    public void deleteVO(Mbj12CodeVO vo) throws HAMException {

        // パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);

        try {
            if (!super.remove()) {
                throw new HAMException("削除エラー", "BJ-E0004");
            }
        } catch(ConcurrentUpdateException e) {
            // 処理件数「0」の場合、正常とする(削除レコードなし)
            return;
        } catch(UpdateFailureException e) {
            // 処理件数「2以上」の場合、正常とする
            return;
        } catch(UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * SelectVO
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj12CodeVO> selectVO(Mbj12CodeCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj12CodeVO());
        _condition = condition;
        _sqlMode = SqlMode.SINGLE;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 複数のコードで検索を行う
     * @param contion 検索条件
     * @return 取得データ
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj12CodeVO> FindManyCd(Mbj12CodeCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new Mbj12CodeVO());
        _condition = condition;
        _sqlMode = SqlMode.MANY;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
