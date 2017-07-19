package jp.co.isid.ham.media.model;

import java.util.Date;
import java.util.HashMap;
import java.util.List;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.model.base.HAMException;

public class CampaignRegisterManager {

    /** シングルトンインスタンス */
    private static CampaignRegisterManager _manager = new CampaignRegisterManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private CampaignRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static CampaignRegisterManager getInstance() {
        return _manager;
    }

    /**
     * キャンペーン一覧情報を登録します
     *
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public void CampaignListIUD(CampaignRegisterCondition cond) throws HAMException {

        //排他チェック
        if (!exclusionCheck(cond))
        {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        CampaignRegisterDAO dao = CampaignRegisterDAOFactory.createCampaignRegisterDAO();

        //削除.
        if (cond.getDelVo() == null || cond.getDelVo().size() == 0) {
        } else {
            for (Tbj12CampaignVO vo : cond.getDelVo()) {
                dao.delCampaignList(vo);
            }
        }
        //登録
        if (cond.getInsVo() == null || cond.getInsVo().size() == 0) {
        } else {
            //キャンペーンNoの最大値を取得します.
            Tbj12CampaignDAO cadao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
            List<Tbj12CampaignVO> campresult = cadao.findMaxCampCd();
            if (campresult.size() == 0) {
                throw new HAMException("検索エラー", "BJ-E0001");
            }
            String maxCampNo = campresult.get(0).getCAMPCD();
            maxCampNo =  maxCampNo.replace("CP", "");
            int count = Integer.parseInt( maxCampNo);
            count ++;
            for (Tbj12CampaignVO vo : cond.getInsVo()) {
                vo.setCAMPCD("CP" + String.format("%1$05d", count));
                dao.insCampaignList(vo);
                count ++;
            }
        }
        //更新
        if (cond.getUpdVo() == null || cond.getUpdVo().size() == 0) {
        } else {
            for (Tbj12CampaignVO vo : cond.getUpdVo()) {
                dao.updCampaignList(vo);
            }
        }
    }

    /**
     * 排他チェックを行います
     * @param cond
     * @return
     * @throws HAMException
     */
    private boolean exclusionCheck(CampaignRegisterCondition cond) throws HAMException {

        FindCampaignListDAO dao = FindCarCampaignListDAOFactory.createFindCampaignListDAO();
        FindCampaignListCondition toCond = new FindCampaignListCondition();

        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            toCond.setDCarCd(cond.getUpdVo().get(0).getDCARCD());
            toCond.setPhase(cond.getUpdVo().get(0).getPHASE().toString());
        } else if (cond.getDelVo() != null && cond.getDelVo().size() > 0) {
            toCond.setDCarCd(cond.getDelVo().get(0).getDCARCD());
            toCond.setPhase(cond.getDelVo().get(0).getPHASE().toString());
        } else {
            return true;
        }

        //再検索をする.
        List<Tbj12CampaignVO> list = dao.findCampaignListByCond(toCond);

        // 比較を簡略化するために、HashMapに型を変換
        HashMap<String, Date> hm = new HashMap<String, Date>();
        for (Tbj12CampaignVO cVo : list) {
            hm.put(cVo.getCAMPCD(), cVo.getUPDDATE());
        }

        boolean error = false;

        //更新対象排他チェック
        if (cond.getUpdVo() != null && cond.getUpdVo().size() > 0) {
            for (Tbj12CampaignVO cVo : cond.getUpdVo()) {
                if (!hm.containsKey(cVo.getCAMPCD())) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(hm.get(cVo.getCAMPCD()))) {
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
            for (Tbj12CampaignVO cVo : cond.getDelVo()) {
                if (!hm.containsKey(cVo.getCAMPCD())) {
                    error = true;
                    break;
                }

                if (cond.getLatestDate().before(hm.get(cVo.getCAMPCD()))) {
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
