package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.Tbj12Campaign;
import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

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
public class FindCampaignListDAO extends AbstractRdbDao {

    /** データ検索条件 */
    private FindCampaignListCondition _cond;

    private enum SqlMode{CAMPAIGN,CAMPAIGNTODETAILS};
    private SqlMode _sqlmode = SqlMode.CAMPAIGN;

    /**
     * デフォルトコンストラクタ
     */
    public FindCampaignListDAO() {
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
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        // new String[] {};
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
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        String sql = null;

        if (_sqlmode.equals(SqlMode.CAMPAIGN)) {
            sql = getCampaignList();
        } else if (_sqlmode.equals(SqlMode.CAMPAIGNTODETAILS)) {
            sql = getCampListToCampDetails();
        }

        return sql;
    }

    /**
     * キャンペーン一覧のSQL文を返します
     *
     * @return String SQL文
     */
    private String getCampaignList() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        //全項目を取得
        for (int i = 0; i < getTableColumnNames().length; i++) {
            if (i == 0) {
                sql.append("  " + getTableColumnNames()[i] + " ");
            } else {
                sql.append(" ," + getTableColumnNames()[i] + " ");
            }
        }
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj12Campaign.DCARCD + "= '" + _cond.getDCarCd() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.PHASE + "= " + _cond.getPhase() + " ");
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj12Campaign.KIKANFROM + ", ");
        sql.append(" " + Tbj12Campaign.CAMPCD + " ");

        return sql.toString();
    }

    private String getCampListToCampDetails() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj12Campaign.CAMPCD);
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + ", ");
        sql.append(" "+ Tbj13CampDetail.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj12Campaign.DCARCD + "= '" + _cond.getDCarCd() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.PHASE + "= " + _cond.getPhase() + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj12Campaign.CAMPCD + "= " + Tbj13CampDetail.CAMPCD + " ");
        sql.append(" GROUP BY ");
        sql.append(" " + Tbj12Campaign.CAMPCD);
        sql.append(" ORDER BY ");
        sql.append(" " + Tbj12Campaign.CAMPCD);

        return sql.toString();
    }

    /**
     * キャンペーン一覧の検索を行います
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findCampaignListByCond(FindCampaignListCondition cond) throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _cond = cond;
            _sqlmode = SqlMode.CAMPAIGN;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * キャンペーン一覧にて詳細を持っているキャンペーンコードを取得する.
     *
     * @return キャンペーン一覧VOリスト
     * @throws UserException
     *             データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj12CampaignVO> findCampaignToDetailsByCond(FindCampaignListCondition cond) throws HAMException {

        super.setModel(new Tbj12CampaignVO());

        try {
            _cond = cond;
            _sqlmode = SqlMode.CAMPAIGNTODETAILS;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "E0002");
        }
    }

    /**
     * Modelの生成を行う<br>
     * 検索結果のVOのKEYが大文字のため変換処理を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList
     *            List 検索結果
     * @return List<FindJissiNoCntCondVO> 変換後の検索結果
     */
    @Override
    protected List<Tbj12CampaignVO> createFindedModelInstances(List hashList) {

        List<Tbj12CampaignVO> list = new ArrayList<Tbj12CampaignVO>();

        if (getModel() instanceof Tbj12CampaignVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                Tbj12CampaignVO vo = new Tbj12CampaignVO();

                vo.setCAMPCD((String)result.get(Tbj12Campaign.CAMPCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Tbj12Campaign.DCARCD.toUpperCase()));
                vo.setPHASE((BigDecimal)result.get(Tbj12Campaign.PHASE.toUpperCase()));
                vo.setKIKANFROM((Date)result.get(Tbj12Campaign.KIKANFROM.toUpperCase()));
                vo.setKIKANTO((Date)result.get(Tbj12Campaign.KIKANTO.toUpperCase()));
                vo.setCAMPNM((String)result.get(Tbj12Campaign.CAMPNM.toUpperCase()));
                vo.setFSTBUDGET((BigDecimal)result.get(Tbj12Campaign.FSTBUDGET.toUpperCase()));
                vo.setBUDGET((BigDecimal)result.get(Tbj12Campaign.BUDGET.toUpperCase()));
                vo.setBUDGETHM((BigDecimal)result.get(Tbj12Campaign.BUDGETHM.toUpperCase()));
                vo.setACTUAL((BigDecimal)result.get(Tbj12Campaign.ACTUAL.toUpperCase()));
                vo.setACTUALHM((BigDecimal)result.get(Tbj12Campaign.ACTUALHM.toUpperCase()));
                vo.setMEMO((String)result.get(Tbj12Campaign.MEMO.toUpperCase()));
                vo.setBAITAIFLG((String)result.get(Tbj12Campaign.BAITAIFLG.toUpperCase()));
                vo.setCRTDATE((Date)result.get(Tbj12Campaign.CRTDATE.toUpperCase()));
                vo.setCRTNM((String)result.get(Tbj12Campaign.CRTNM.toUpperCase()));
                vo.setCRTAPL((String)result.get(Tbj12Campaign.CRTAPL.toUpperCase()));
                vo.setCRTID((String)result.get(Tbj12Campaign.CRTID.toUpperCase()));
                vo.setUPDDATE((Date)result.get(Tbj12Campaign.UPDDATE.toUpperCase()));
                vo.setUPDNM((String)result.get(Tbj12Campaign.UPDNM.toUpperCase()));
                vo.setUPDAPL((String)result.get(Tbj12Campaign.UPDAPL.toUpperCase()));
                vo.setUPDID((String)result.get(Tbj12Campaign.UPDID.toUpperCase()));

                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }

        return list;
    }

}
