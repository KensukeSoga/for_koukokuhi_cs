package jp.co.isid.ham.media.model;


import jp.co.isid.ham.common.model.Tbj13CampDetailCondition;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;


/**
 *
 * <P>
 * キャンペーン詳細の更新DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/14 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class CampaignRegisterDetailsDAO extends AbstractSimpleRdbDao {


    /** データ検索条件 */
    private Tbj13CampDetailCondition _cond;

    private enum ExecSqlMode{DEL};
    private ExecSqlMode _execSqlMode = ExecSqlMode.DEL;

    private enum SqlMode{INS,UPD,DEL};
    private SqlMode _sqlmode = SqlMode.INS;

    /**
     * デフォルトコンストラクタ
     */
    public CampaignRegisterDetailsDAO() {
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
                Tbj13CampDetail.CAMPCD,
                Tbj13CampDetail.MEDIACD,
                Tbj13CampDetail.PHASE,
                Tbj13CampDetail.YOTEIYM
        };
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj13CampDetail.CRTDATE;
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
                    Tbj13CampDetail.CRTDATE,
                    Tbj13CampDetail.UPDDATE
            };
        } else if (_sqlmode.equals(SqlMode.UPD)) {
            return new String[]{
                    Tbj13CampDetail.UPDDATE
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
        return Tbj13CampDetail.TBNAME;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj13CampDetail.CAMPCD,
                Tbj13CampDetail.DCARCD,
                Tbj13CampDetail.MEDIACD,
                Tbj13CampDetail.PHASE,
                Tbj13CampDetail.YOTEIYM,
                Tbj13CampDetail.KIKANFROM,
                Tbj13CampDetail.KIKANTO,
                Tbj13CampDetail.BUDGET,
                Tbj13CampDetail.BUDGETHM,
                Tbj13CampDetail.CRTDATE,
                Tbj13CampDetail.CRTNM,
                Tbj13CampDetail.CRTAPL,
                Tbj13CampDetail.CRTID,
                Tbj13CampDetail.UPDDATE,
                Tbj13CampDetail.UPDNM,
                Tbj13CampDetail.UPDAPL,
                Tbj13CampDetail.UPDID

        };
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getExecString() {
        if (_execSqlMode.equals(ExecSqlMode.DEL)) {
            return getDelCampaignDetail();
        }
        return null;

    }

    /**
     * 対象のキャンペーンコードを持つキャンペーン詳細データを全て削除
     * @return sql文
     */
    public String getDelCampaignDetail() {
        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE ");
        sql.append(" FROM ");
        sql.append(" " + Tbj13CampDetail.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.CAMPCD + " ='" + _cond.getCampcd() + "' ");

        return sql.toString();
    }

    /**
     * キャンペーン詳細データの削除を行います
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void delCampaignDetails(
            Tbj13CampDetailVO vo) throws HAMException {
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
     * キャンペーン詳細データの登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insCampaignDetails(
            Tbj13CampDetailVO vo) throws HAMException {

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
     * キャンペーン詳細データの更新を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void updCampaignDetails(
            Tbj13CampDetailVO vo) throws HAMException {
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
     * 対象のキャンペーンコードを持つキャンペーン詳細データを削除します.
     * @param campCd
     * @throws HAMException
     */
    public void delCampaignDetailsByCd(Tbj13CampDetailCondition cond) throws HAMException {

        try {
            _execSqlMode = ExecSqlMode.DEL;
            _cond = cond;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }
}