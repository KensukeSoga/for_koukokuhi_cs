package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj32Compurpose;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * 汎用コメントDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj32CompurposeDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Tbj32CompurposeCondition _condition = null;
    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{ LOAD };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj32CompurposeDAO() {
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
                Tbj32Compurpose.CODETYPE
                ,Tbj32Compurpose.FORMID
                ,Tbj32Compurpose.PHASE
                ,Tbj32Compurpose.KEYCODE1
                ,Tbj32Compurpose.KEYCODE2
                ,Tbj32Compurpose.KEYCODE3
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj32Compurpose.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj32Compurpose.CRTDATE
               ,Tbj32Compurpose.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj32Compurpose.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj32Compurpose.CODETYPE
                ,Tbj32Compurpose.FORMID
                ,Tbj32Compurpose.PHASE
                ,Tbj32Compurpose.KEYCODE1
                ,Tbj32Compurpose.KEYCODE2
                ,Tbj32Compurpose.KEYCODE3
                ,Tbj32Compurpose.CONTENTS1
                ,Tbj32Compurpose.CONTENTS2
                ,Tbj32Compurpose.CONTENTM1
                ,Tbj32Compurpose.CONTENTM2
                ,Tbj32Compurpose.CONTENTL1
                ,Tbj32Compurpose.CONTENTL2
                ,Tbj32Compurpose.CRTDATE
                ,Tbj32Compurpose.CRTNM
                ,Tbj32Compurpose.CRTAPL
                ,Tbj32Compurpose.CRTID
                ,Tbj32Compurpose.UPDDATE
                ,Tbj32Compurpose.UPDNM
                ,Tbj32Compurpose.UPDAPL
                ,Tbj32Compurpose.UPDID
        };
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
        }

        return sql.toString();
    };

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj32CompurposeVO loadVO(Tbj32CompurposeVO cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(cond);
        try {
            return (Tbj32CompurposeVO)super.load();
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
    public boolean insertVO(Tbj32CompurposeVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            return super.insert();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
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
    public boolean updateVO(Tbj32CompurposeVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        super.setModel(vo);
        try {
            return super.update();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
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
    public boolean deleteVO(Tbj32CompurposeVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        super.setModel(vo);
        try {
            return super.remove();
        } catch (ConcurrentUpdateException e) {
            //処理件数が0件の場合.
            return false;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

}
