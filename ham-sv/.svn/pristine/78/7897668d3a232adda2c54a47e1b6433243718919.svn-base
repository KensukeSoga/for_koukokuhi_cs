package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Mbj37DisplayControl;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 画面項目表示列制御マスタDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Mbj37DisplayControlDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
    private Mbj37DisplayControlCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, COND, MODE2,};
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Mbj37DisplayControlDAO() {
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
                Mbj37DisplayControl.FORMID
                ,Mbj37DisplayControl.VIEWID
                ,Mbj37DisplayControl.COLCNT
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Mbj37DisplayControl.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Mbj37DisplayControl.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Mbj37DisplayControl.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Mbj37DisplayControl.FORMID
                ,Mbj37DisplayControl.VIEWID
                ,Mbj37DisplayControl.COLCNT
                ,Mbj37DisplayControl.COLNM
                ,Mbj37DisplayControl.COLWIDTH
                ,Mbj37DisplayControl.DISPLAYKBN
                ,Mbj37DisplayControl.CONTROLKBN
                ,Mbj37DisplayControl.UPDDATE
                ,Mbj37DisplayControl.UPDNM
                ,Mbj37DisplayControl.UPDAPL
                ,Mbj37DisplayControl.UPDID
        };
    }

    /**
     * SELECT SQL
     */
    @Override
    public String getSelectSQL() {
        StringBuffer selectSql = new StringBuffer();
        StringBuffer whereSql = new StringBuffer();
        StringBuffer orderbySql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " ")); //三項演算子嫌い
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.COND)) {

            //*******************************************
            //findMbj37DisplayControlByCondで使用されるSQL
            //*******************************************

            //SELECT + FROM句
            selectSql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                selectSql.append((i != 0 ? " ," : " ")); //三項演算子嫌い
                selectSql.append("" + getTableColumnNames()[i] +" ");
            }
            selectSql.append(" FROM ");
            selectSql.append(" " + getTableName() + " ");

            //WHERE句
            whereSql.append(" WHERE ");
            whereSql.append(" " + Mbj37DisplayControl.FORMID + " = '" + _condition.getFormid() + "' ");
            if (_condition.getViewid() != null) {
                whereSql.append(" AND ");
                whereSql.append(" " + Mbj37DisplayControl.VIEWID + " = '" + _condition.getViewid() + "' ");
            }
            if (_condition.getColcnt() != null) {
                whereSql.append(" AND ");
                whereSql.append(" " + Mbj37DisplayControl.COLCNT + " = " + _condition.getColcnt() + " ");
            }

            //ORDER BY句
            orderbySql.append(" ORDER BY ");
            orderbySql.append(Mbj37DisplayControl.FORMID);
            orderbySql.append(", ");
            orderbySql.append(Mbj37DisplayControl.VIEWID);
            orderbySql.append(", ");
            orderbySql.append(Mbj37DisplayControl.COLCNT);
        }

        return selectSql.toString() + whereSql.toString() + orderbySql.toString();
    };

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Mbj37DisplayControlVO> selectVO(Mbj37DisplayControlCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        if (cond.getFormid() == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Mbj37DisplayControlVO());
        try {
            _SelSqlMode = SelSqlMode.COND;
            _condition = cond;
            return (List<Mbj37DisplayControlVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Mbj37DisplayControlVO loadVO(Mbj37DisplayControlVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Mbj37DisplayControlVO)super.load();
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
    public void insertVO(Mbj37DisplayControlVO vo) throws HAMException {
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
    public void updateVO(Mbj37DisplayControlVO vo) throws HAMException {
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
    public void deleteVO(Mbj37DisplayControlVO vo) throws HAMException {
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

}
