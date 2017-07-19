package jp.co.isid.ham.common.model;

import jp.co.isid.ham.integ.tbl.Tbj33CrBudgetUpdHis;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.ConcurrentUpdateException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 * <P>
 * CR予算更新履歴DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj33CrBudgetUpdHisDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Tbj33CrBudgetUpdHisCondition _condition = null;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj33CrBudgetUpdHisDAO() {
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
        return Tbj33CrBudgetUpdHis.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj33CrBudgetUpdHis.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj33CrBudgetUpdHis.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj33CrBudgetUpdHis.PHASE
                ,Tbj33CrBudgetUpdHis.DCARCD
                ,Tbj33CrBudgetUpdHis.CLASSCD
                ,Tbj33CrBudgetUpdHis.EXPCD
                ,Tbj33CrBudgetUpdHis.CRTDATE
                ,Tbj33CrBudgetUpdHis.CRTNM
                ,Tbj33CrBudgetUpdHis.CRTAPL
                ,Tbj33CrBudgetUpdHis.CRTID
                ,Tbj33CrBudgetUpdHis.UPDDATE
                ,Tbj33CrBudgetUpdHis.UPDNM
                ,Tbj33CrBudgetUpdHis.UPDAPL
                ,Tbj33CrBudgetUpdHis.UPDID
        };
    }



    /**
     * 登録
     * @param vo
     * @return
     * @throws HAMException
     */
    public boolean insertVO(Tbj33CrBudgetUpdHisVO vo) throws HAMException {
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
    public boolean updateVO(Tbj33CrBudgetUpdHisVO vo) throws HAMException {
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
    public boolean deleteVO(Tbj33CrBudgetUpdHisVO vo) throws HAMException {
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
