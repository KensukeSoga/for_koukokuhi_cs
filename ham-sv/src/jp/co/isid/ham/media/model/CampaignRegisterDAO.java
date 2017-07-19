package jp.co.isid.ham.media.model;


import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;


/**
 *
 * <P>
 * キャンペーン一覧の情報取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 FM H.Izawa)<BR>
 * </P>
 *
 * @author FM H.Izawa
 */
public class CampaignRegisterDAO extends AbstractSimpleRdbDao {

    private enum SqlMode{INS,UPD,DEL};
    private SqlMode _sqlmode = SqlMode.INS;
    /**
     * デフォルトコンストラクタ
     */
    public CampaignRegisterDAO() {
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
                Tbj12Campaign.CAMPCD
        };
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj12Campaign.CRTDATE;
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
                    Tbj12Campaign.CRTDATE,
                    Tbj12Campaign.UPDDATE
            };
        } else if (_sqlmode.equals(SqlMode.UPD)) {
            return new String[]{
                    Tbj12Campaign.UPDDATE
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
        return Tbj12Campaign.TBNAME;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[]{
                Tbj12Campaign.CAMPCD,
                Tbj12Campaign.DCARCD,
                Tbj12Campaign.PHASE,
                Tbj12Campaign.KIKANFROM,
                Tbj12Campaign.KIKANTO,
                Tbj12Campaign.CAMPNM,
                Tbj12Campaign.FSTBUDGET,
                Tbj12Campaign.BUDGET,
                Tbj12Campaign.BUDGETHM,
                Tbj12Campaign.ACTUAL,
                Tbj12Campaign.ACTUALHM,
                Tbj12Campaign.MEMO,
                Tbj12Campaign.BAITAIFLG,
                Tbj12Campaign.CRTDATE,
                Tbj12Campaign.CRTNM,
                Tbj12Campaign.CRTAPL,
                Tbj12Campaign.CRTID,
                Tbj12Campaign.UPDDATE,
                Tbj12Campaign.UPDNM,
                Tbj12Campaign.UPDAPL,
                Tbj12Campaign.UPDID
        };
    }

    /**
     * キャンペーン一覧の削除を行います
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void delCampaignList(
            Tbj12CampaignVO vo) throws HAMException {
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
     * キャンペーン一覧の登録を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void insCampaignList(
            Tbj12CampaignVO vo) throws HAMException {

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
     * キャンペーン一覧の更新を行います.
     *
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    public void updCampaignList(
            Tbj12CampaignVO vo) throws HAMException {

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

}