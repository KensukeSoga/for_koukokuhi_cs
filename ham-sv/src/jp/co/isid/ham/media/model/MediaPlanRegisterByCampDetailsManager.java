package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.*;
import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class MediaPlanRegisterByCampDetailsManager {

    /** シングルトンインスタンス */
    private static MediaPlanRegisterByCampDetailsManager _manager = new MediaPlanRegisterByCampDetailsManager();

    private MediaPlanRegisterCondition _cond;


    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private MediaPlanRegisterByCampDetailsManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static MediaPlanRegisterByCampDetailsManager getInstance() {
        return _manager;
    }

    /**
     * 媒体状況管理データ情報を登録します
     *
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public void MediaPlanRegister(MediaPlanRegisterCondition cond)
            throws HAMException {
        _cond = cond;

        if (cond.getInsOnlyFlg()) {
            insOnly();
        } else {
            //キャンペーン詳細の更新.
            CampaignRegisterDetailsCondition crdCond = new CampaignRegisterDetailsCondition();
            crdCond.setDelVo(cond.getDeDelVo());
            crdCond.setInsVo(cond.getDeInsVo());
            crdCond.setUpdVo(cond.getDeUpdVo());
            crdCond.setHamId(cond.getHamId());
            crdCond.setHamNm(cond.getHamNm());
            crdCond.setUpdApl(cond.getUpdApl());
            crdCond.setDataCount(cond.getDataCount());
            crdCond.setLatestDate(cond.getLatestDate());
            crdCond.setLatestPel(cond.getLatestUpdId());
            CampaignRegisterDetailsManager mane = CampaignRegisterDetailsManager.getInstance();
            mane.CampaignDetailsIUD(crdCond);
            saiSakusei();
        }

        //*************************************************
        //キャンペーン一覧の媒体状況登録フラグの更新
        //*************************************************
        Tbj12CampaignDAO camDao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        String cCampCd = null;
        String BaitaiFlg = null;
        //登録がある場合.
        if (_cond.getInsVo() != null && !_cond.getInsVo().equals("")) {
            cCampCd = _cond.getInsVo().get(0).getCAMPCD();
        }
        if (_cond.getDeUpdVo() != null && !_cond.getDeUpdVo().equals("")) {
            cCampCd = _cond.getDeUpdVo().get(0).getCAMPCD();
        }
        if (_cond.getDeDelVo() != null && !_cond.getDeDelVo().equals("")) {
            cCampCd = _cond.getDeDelVo().get(0).getCAMPCD();
        }

        //キャンペーンの媒体状況データが何件あるかを確認0件の場合は媒体フラグを0にする.
        Tbj01MediaPlanDAO mmdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mmlist = mmdao.findMediaPlanByCampCd(cCampCd);

        if (mmlist.size() == 0) {
            BaitaiFlg = "0";
        } else {
            BaitaiFlg = "1";
        }

        List<Tbj12CampaignVO> camList =  camDao.findCampaignListByCampCd(cCampCd);
        if (camList.size() == 0) {
            //キャンペーン取得エラー.
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        //キャンペーンコードは主キーの為1行しか取れない.
        Tbj12CampaignVO camVo = camList.get(0);
        camVo.setBAITAIFLG(BaitaiFlg);
        CampaignRegisterDAO reDao = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
        reDao.updCampaignList(camVo);
    }

    /**
     *媒体状況管理に初めて登録する場合.
     * @throws HAMException
     */
    private void insOnly() throws HAMException {
        Tbj01MediaPlanDAO mediaDao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> maxList = mediaDao.findMediaPlanMaxCd();
        if (maxList.size() == 0) {
            //Max値取得エラー
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        BigDecimal maxCd = maxList.get(0).getMEDIAPLANNO();
        int imaxcd =maxCd.intValue();

        //１件ずつ登録していく.
        for (Tbj01MediaPlanVO vo : _cond.getInsVo()) {
            //媒体管理Noの加算
            imaxcd++;
            //費用企画Noを取得
            List<Mbj09HiyouVO> hiList = findHiyou(vo);
            //費用企画NoをinsertVoに設定する
            if (hiList.size() == 0) {
                vo.setHIYOUNO("");
            } else {
                vo.setHIYOUNO( hiList.get(0).getHIYOUNO());
            }
            //媒体管理Noを設定する
            vo.setMEDIAPLANNO(new BigDecimal(imaxcd));
            MediaPlanRegisterDAO mpdao = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();
            mpdao.insMediaPlan(vo);
        }
    }

    /**
     * 媒体状況管理再作成の場合
     * @throws HAMException
     */
    private void saiSakusei() throws HAMException {

        //媒体状況管理
        Tbj01MediaPlanDAO mDao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        MediaPlanRegisterDAO mrDao = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();

        //削除VOが存在するか
        if (_cond.getDeDelVo() != null && !_cond.getDeDelVo().equals("")) {

            for (Tbj13CampDetailVO dedVo : _cond.getDeDelVo()) {
                //媒体管理Noの取得
                List<Tbj01MediaPlanVO> mediaCdlist = mDao.findMediaPlanByCond(dedVo);
                if (mediaCdlist.size() == 0) {
                    throw new HAMException("検索エラー", "BJ-E0001");
                }

                //媒体状況管理を削除.
                mrDao.delMediaPlan(mediaCdlist.get(0));
            }
        }

        //登録用VOが存在するか
        if (_cond.getDeInsVo() != null && !_cond.getDeInsVo().equals("")) {

            //媒体状況管理Noの最大値を取得
            List<Tbj01MediaPlanVO> maxlist =  mDao.findMediaPlanMaxCd();
            BigDecimal max = maxlist.get(0).getMEDIAPLANNO();
            int imax =0;
            if (maxlist.size() == 0) {
                imax = 1;
            } else {
                imax = max.intValue();
            }

            for (Tbj01MediaPlanVO insVo : _cond.getInsVo()) {
                imax++;
                //費用企画Noを取得
                List<Mbj09HiyouVO> hiList = findHiyou(insVo);
                //費用企画NoをinsertVoに設定する
                if (hiList.size() == 0) {
                    insVo.setHIYOUNO("");
                } else {
                    insVo.setHIYOUNO( hiList.get(0).getHIYOUNO());
                }
                //媒体管理Noを設定する
                insVo.setMEDIAPLANNO(new BigDecimal(imax));
                //登録
                mrDao.insMediaPlan(insVo);
            }
        }

        if (_cond.getDeUpdVo() != null && !_cond.getDeUpdVo().equals("")) {

            for (Tbj13CampDetailVO updVo : _cond.getDeUpdVo()) {
                //媒体状況管理Noの取得
                List<Tbj01MediaPlanVO> mplist = mDao.findMediaPlanByCond(updVo);
                if (mplist.size() == 0) {
                    throw new HAMException("検索エラー", "BJ-E0001");
                }
                Tbj01MediaPlanVO addVo = mplist.get(0);
                //予算の更新.
                addVo.setBUDGET(updVo.getBUDGET());
                addVo.setBUDGETHM(updVo.getBUDGETHM());
                //差額の更新.
                addVo.setDIFAMT(updVo.getBUDGET().subtract(addVo.getACTUAL()));
                addVo.setDIFAMTHM(updVo.getBUDGETHM().subtract(addVo.getACTUALHM()));
                //更新
                mrDao.updMediaPlan(addVo);
            }
        }
    }

    /**
     *
     * 費用企画Noの取得を行う.
     * @param 媒体状況管理No.
     * @return 費用マスタのリスト
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> findHiyou(Tbj01MediaPlanVO vo) throws HAMException {

        //費用企画Noをマスタから取得する
        Mbj09HiyouCondition hiCond = new  Mbj09HiyouCondition();
        hiCond.setMediacd(vo.getMEDIACD());
        hiCond.setDcarcd(vo.getDCARCD());
        hiCond.setPhase(vo.getPHASE());
        hiCond.setTerm(vo.getTERM());
        Mbj09HiyouDAO hiDao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();

        return hiDao.selectVO(hiCond);
    }

}
