package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.integ.tbl.Mbj03Media;
import jp.co.isid.ham.integ.tbl.Tbj13CampDetail;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
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
public class FindCampaignDetailsDAO extends AbstractRdbDao {


    /** データ検索条件 */
    private FindCampaignDetailsCondition _cond;


    /**
     * デフォルトコンストラクタ
     */
    public FindCampaignDetailsDAO() {
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
        return Tbj13CampDetail.TBNAME;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        return getCampaignList();
    }

    /**
     * キャンペーン一覧のSQL文を返します
     *
     * @return String SQL文
     */
    private String getCampaignList()
    {
        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" * ");
        sql.append(" FROM ");
        sql.append(" "+ getTableName() + ", ");
        sql.append(" "+ Mbj03Media.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj13CampDetail.MEDIACD + "= " + Mbj03Media.MEDIACD + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj13CampDetail.CAMPCD+ "= '" + _cond.getCampaignNo() + "' ");
        sql.append(" ORDER BY ");
        sql.append(" " + Mbj03Media.SORTNO + ", ");
        sql.append(" " + Tbj13CampDetail.KIKANFROM+ " ");


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
    public List<FindCampaignDetailstVO> findCampaignListByCond(
            FindCampaignDetailsCondition cond) throws HAMException {

        super.setModel(new FindCampaignDetailstVO());

        try {
            _cond = cond;
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
    protected List<FindCampaignDetailstVO> createFindedModelInstances(List hashList) {

        List<FindCampaignDetailstVO> list = new ArrayList<FindCampaignDetailstVO>();

        if (getModel() instanceof FindCampaignDetailstVO) {

            for (int i = 0; i < hashList.size(); i++) {

                Map result = (Map) hashList.get(i);
                FindCampaignDetailstVO vo = new FindCampaignDetailstVO();

                vo.setCAMPCD((String)result.get(Tbj13CampDetail.CAMPCD.toUpperCase()));
                vo.setDCARCD((String)result.get(Tbj13CampDetail.DCARCD.toUpperCase()));
                vo.setMEDIACD((String)result.get(Tbj13CampDetail.MEDIACD.toUpperCase()));
                vo.setPHASE((BigDecimal)result.get(Tbj13CampDetail.PHASE.toUpperCase()));
                vo.setYOTEIYM((Date)result.get(Tbj13CampDetail.YOTEIYM.toUpperCase()));
                vo.setKIKANFROM((Date)result.get(Tbj13CampDetail.KIKANFROM.toUpperCase()));
                vo.setKIKANTO((Date)result.get(Tbj13CampDetail.KIKANTO.toUpperCase()));
                vo.setBUDGET((BigDecimal)result.get(Tbj13CampDetail.BUDGET.toUpperCase()));
                vo.setBUDGETHM((BigDecimal)result.get(Tbj13CampDetail.BUDGETHM.toUpperCase()));
                vo.setCRTDATE((Date)result.get(Tbj13CampDetail.CRTDATE.toUpperCase()));
                vo.setCRTNM((String)result.get(Tbj13CampDetail.CRTNM.toUpperCase()));
                vo.setCRTAPL((String)result.get(Tbj13CampDetail.CRTAPL.toUpperCase()));
                vo.setCRTID((String)result.get(Tbj13CampDetail.CRTID.toUpperCase()));
                vo.setUPDDATE((Date)result.get(Tbj13CampDetail.UPDDATE.toUpperCase()));
                vo.setUPDNM((String)result.get(Tbj13CampDetail.UPDNM.toUpperCase()));
                vo.setUPDAPL((String)result.get(Tbj13CampDetail.UPDAPL.toUpperCase()));
                vo.setUPDID((String)result.get(Tbj13CampDetail.UPDID.toUpperCase()));
                vo.setMEDIANM((String)result.get(Mbj03Media.MEDIANM.toUpperCase()));
                vo.setHCMEDIANM((String)result.get(Mbj03Media.HCMEDIANM.toUpperCase()));
                vo.setDNEBIKI((BigDecimal)result.get(Mbj03Media.DNEBIKI.toUpperCase()));
                vo.setSORTNO((BigDecimal)result.get(Mbj03Media.SORTNO.toUpperCase()));
                vo.setMEDIAUPDDATE((Date)result.get(Mbj03Media.UPDDATE.toUpperCase()));


                // 検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }
        return list;
    }

}