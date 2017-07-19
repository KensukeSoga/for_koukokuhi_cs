package jp.co.isid.ham.media.model;

import jp.co.isid.ham.integ.tbl.Tbj01MediaPlan;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;

/**
 *
 * <P>
 * 媒体状況管理の更新DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/17 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class MediaPlanRegisterDAO extends AbstractSimpleRdbDao {

    private enum SqlMode{INS,UPD,DEL,DELINS};
    private SqlMode _sqlmode = SqlMode.INS;
    /**
     * デフォルトコンストラクタ
     */
    public MediaPlanRegisterDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[]{
                Tbj01MediaPlan.CAMPCD,
                Tbj01MediaPlan.MEDIAPLANNO
        };
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        if (_sqlmode.equals(SqlMode.DELINS)) {
            return null;
        }
        else
        {
            return Tbj01MediaPlan.CRTDATE;
        }
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        if (_sqlmode.equals(SqlMode.INS)) {
            return new String[]{
                    Tbj01MediaPlan.CRTDATE,
                    Tbj01MediaPlan.UPDDATE
            };
        } else if (_sqlmode.equals(SqlMode.UPD)) {
            return new String[]{
                    Tbj01MediaPlan.UPDDATE
            };
        } else if (_sqlmode.equals(SqlMode.DELINS)) {
            return new String[]{
                    Tbj01MediaPlan.UPDDATE
            };
        }

        return null;

    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj01MediaPlan.TBNAME;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj01MediaPlan.CAMPCD,
                Tbj01MediaPlan.MEDIAPLANNO,
                Tbj01MediaPlan.YOTEIYM,
                Tbj01MediaPlan.KEIRESTUCD,
                Tbj01MediaPlan.DCARCD,
                Tbj01MediaPlan.MEDIACD,
                Tbj01MediaPlan.HIYOUNO,
                Tbj01MediaPlan.AGENCY,
                Tbj01MediaPlan.KENMEI,
                Tbj01MediaPlan.MEMO,
                Tbj01MediaPlan.PHASE,
                Tbj01MediaPlan.TERM,
                Tbj01MediaPlan.KIKANFROM,
                Tbj01MediaPlan.KIKANTO,
                Tbj01MediaPlan.HMOK,
                Tbj01MediaPlan.BUYEROK,
                Tbj01MediaPlan.BUDGET,
                Tbj01MediaPlan.BUDGETHM,
                Tbj01MediaPlan.ACTUAL,
                Tbj01MediaPlan.ACTUALHM,
                Tbj01MediaPlan.ADJUSTMENT,
                Tbj01MediaPlan.DIFAMT,
                Tbj01MediaPlan.DIFAMTHM,
                Tbj01MediaPlan.BUDGETUPDFLG,
                Tbj01MediaPlan.CRTDATE,
                Tbj01MediaPlan.CRTNM,
                Tbj01MediaPlan.CRTAPL,
                Tbj01MediaPlan.CRTID,
                Tbj01MediaPlan.UPDDATE,
                Tbj01MediaPlan.UPDNM,
                Tbj01MediaPlan.UPDAPL,
                Tbj01MediaPlan.UPDID
        };
    }

    /**
     * 媒体状況管理データの削除を行います
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void delMediaPlan(
            Tbj01MediaPlanVO vo) throws HAMException {
        super.setModel(vo);
        try {
            _sqlmode = SqlMode.DEL;
            if (!super.remove())
            {
                throw new HAMException("削除エラー","BJ-E0004");
            }

        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 媒体状況管理データの登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insMediaPlan(
            Tbj01MediaPlanVO vo) throws HAMException {

        super.setModel(vo);
        try {
            _sqlmode = SqlMode.INS;
            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }
    /**
     * 媒体状況管理データの更新を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void updMediaPlan(
            Tbj01MediaPlanVO vo) throws HAMException {

        super.setModel(vo);
        try {
            _sqlmode = SqlMode.UPD;
            if (!super.update()) {
                throw new HAMException("更新エラー", "BJ-E0003");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }
    /**
     * 媒体状況管理データの登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void delinsMediaPlan(
            Tbj01MediaPlanVO vo) throws HAMException {

        super.setModel(vo);
        try {
            _sqlmode = SqlMode.DELINS;
            if (!super.insert()) {
                throw new HAMException("登録エラー", "BJ-E0002");
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }

    }
}