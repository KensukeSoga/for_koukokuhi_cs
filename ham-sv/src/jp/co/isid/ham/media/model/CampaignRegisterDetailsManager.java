package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAO;
import jp.co.isid.ham.common.model.Tbj13CampDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class CampaignRegisterDetailsManager {

    /** シングルトンインスタンス */
    private static CampaignRegisterDetailsManager _manager = new CampaignRegisterDetailsManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private CampaignRegisterDetailsManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static CampaignRegisterDetailsManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン詳細データ情報を登録します
     *
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public void CampaignDetailsIUD(CampaignRegisterDetailsCondition cond) throws HAMException {

        //排他チェック
        if (!exclusionCheck(cond)) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        /**キャンペーン詳細一覧更新*/
        CampaignRegisterDetailsDAO dao = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

        //キャンペーン一覧にUPDATEするために保持.
        String campaignCd = "";


        //*************************************************
        //更新処理(キャンペーン詳細)
        //*************************************************
        //削除.
        if (cond.getDelVo() == null || cond.getDelVo().size() == 0) {
        } else {
            campaignCd = cond.getDelVo().get(0).getCAMPCD();
            for (Tbj13CampDetailVO vo : cond.getDelVo()) {
                dao.delCampaignDetails(vo);
            }
        }
        //登録.
        if (cond.getInsVo() == null || cond.getInsVo().size() == 0) {
        } else {
            campaignCd = cond.getInsVo().get(0).getCAMPCD();
            for (Tbj13CampDetailVO vo : cond.getInsVo()) {
                dao.insCampaignDetails(vo);
            }
        }
        //更新.
        if (cond.getUpdVo() == null || cond.getUpdVo().size() == 0) {
        } else {
            campaignCd = cond.getUpdVo().get(0).getCAMPCD();
            for (Tbj13CampDetailVO vo : cond.getUpdVo()) {
                dao.updCampaignDetails(vo);
            }
        }


        //*************************************************
        //更新処理(キャンペーン一覧)
        //*************************************************

        //保持したキャンペーンを使い、キャンペーン一覧を更新する.
        Tbj13CampDetailDAO ddao = Tbj13CampDetailDAOFactory.createTbj13CampDetailDAO();
        //詳細合計を取得
        List<Tbj13CampDetailVO> sumBud =  ddao.findCampaignDetailsSumBudget(campaignCd);

        //詳細の期間を取得
        List<Tbj13CampDetailVO> kikan =  ddao.findCampaignDetailsKikan(campaignCd);

        //詳細データが存在しない場合.
        if (sumBud.size() == 0) {
            return;
        }

        //更新対象の行を取得
        Tbj12CampaignDAO ldao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> camlist =  ldao.findCampaignListByCampCd(campaignCd);

        Tbj12CampaignVO updVo = camlist.get(0);
        //変更が入ったかのチェック.
        boolean upCheck = false;
        //更新対象行と詳細の合計が同じ場合は更新しない
        if (updVo.getBUDGET().equals(sumBud.get(0).getBUDGET()) && updVo.getBUDGETHM().equals(sumBud.get(0).getBUDGETHM())) {
        } else {
            updVo.setBUDGET(sumBud.get(0).getBUDGET());
            updVo.setBUDGETHM(sumBud.get(0).getBUDGETHM());
            updVo.setACTUAL(BigDecimal.valueOf(0));
            updVo.setACTUALHM(BigDecimal.valueOf(0));
            updVo.setUPDID(cond.getHamId());
            updVo.setUPDNM(cond.getHamNm());
            updVo.setUPDAPL(cond.getUpdApl());
            upCheck = true;
        }

        //期間の比較
        Calendar deKikanFrom = Calendar.getInstance();
        deKikanFrom.setTime(kikan.get(0).getKIKANFROM());
        Calendar deKikanTo = Calendar.getInstance();
        deKikanTo.setTime(kikan.get(0).getKIKANTO());
        Calendar liKikanFrom = Calendar.getInstance();
        liKikanFrom.setTime(updVo.getKIKANFROM());
        Calendar liKikanTo = Calendar.getInstance();
        liKikanTo.setTime(updVo.getKIKANTO());

        //月が違ったら開始期間を入れ替える
        if (liKikanFrom.get(Calendar.MONTH) != deKikanFrom.get(Calendar.MONTH)) {
            updVo.setKIKANFROM(kikan.get(0).getKIKANFROM());
            upCheck = true;
        }

        if (liKikanTo.get(Calendar.MONTH) != deKikanTo.get(Calendar.MONTH)) {
            updVo.setKIKANTO(kikan.get(0).getKIKANTO());
            upCheck = true;
        }

        //更新.
        if (upCheck) {
            CampaignRegisterDAO rdao = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
            rdao.updCampaignList(updVo);
        }
    }

    /**
     * 排他チェック
     * @param cond
     * @return
     * @throws HAMException
     */
    private boolean exclusionCheck(CampaignRegisterDetailsCondition cond) throws HAMException {

        Tbj13CampDetailDAO dao = Tbj13CampDetailDAOFactory.createTbj13CampDetailDAO();
        FindCampaignDetailsCondition fcdCond = new FindCampaignDetailsCondition();

        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            fcdCond.setCampaignNo(cond.getUpdVo().get(0).getCAMPCD());
        }
        else if (cond.getDelVo() != null && cond.getDelVo().size() > 0) {
            fcdCond.setCampaignNo(cond.getDelVo().get(0).getCAMPCD());
        }
        else
        {
            return true;
        }

        //キャンペーン詳細取得
        List<Tbj13CampDetailVO> list13 = dao.findCampaignDetailsByCond(fcdCond);

        boolean error = false;

        //更新対象排他チェック
        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            for (Tbj13CampDetailVO cdVo : cond.getUpdVo()) {
                //存在チェック
                boolean exist = false;
                Date updDate = null;
                for (Tbj13CampDetailVO cdVoNow : list13) {
                    if (cdVo.getCAMPCD().equals(cdVoNow.getCAMPCD())
                      && cdVo.getMEDIACD().equals(cdVoNow.getMEDIACD())
                      && cdVo.getPHASE().equals(cdVoNow.getPHASE())
                      && cdVo.getYOTEIYM().equals(cdVoNow.getYOTEIYM())) {
                        exist = true;
                        updDate = cdVoNow.getUPDDATE();
                        break;
                    }
                }

                if (!exist) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(updDate)) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        //削除対象排他チェック
        if (cond.getDelVo() != null && cond.getDelVo().size() > 0) {
            for (Tbj13CampDetailVO cdVo : cond.getDelVo()) {
                //存在チェック
                boolean exist = false;
                Date updDate = null;
                for (Tbj13CampDetailVO cdVoNow : list13) {
                    if (cdVo.getCAMPCD().equals(cdVoNow.getCAMPCD())
                      && cdVo.getMEDIACD().equals(cdVoNow.getMEDIACD())
                      && cdVo.getPHASE().equals(cdVoNow.getPHASE())
                      && cdVo.getYOTEIYM().equals(cdVoNow.getYOTEIYM())) {
                        exist = true;
                        updDate = cdVoNow.getUPDDATE();
                        break;
                    }
                }

                if (!exist) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(updDate)) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        return true;
    }
}
