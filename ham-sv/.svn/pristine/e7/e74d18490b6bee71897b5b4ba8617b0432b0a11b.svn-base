package jp.co.isid.ham.media.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import jp.co.isid.ham.common.model.Mbj09HiyouCondition;
import jp.co.isid.ham.common.model.Mbj09HiyouDAO;
import jp.co.isid.ham.common.model.Mbj09HiyouDAOFactory;
import jp.co.isid.ham.common.model.Mbj09HiyouVO;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanCondition;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAO;
import jp.co.isid.ham.common.model.Tbj01MediaPlanDAOFactory;
import jp.co.isid.ham.common.model.Tbj01MediaPlanVO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAO;
import jp.co.isid.ham.common.model.Tbj12CampaignDAOFactory;
import jp.co.isid.ham.common.model.Tbj12CampaignVO;
import jp.co.isid.ham.common.model.Tbj13CampDetailCondition;
import jp.co.isid.ham.common.model.Tbj13CampDetailVO;
import jp.co.isid.ham.model.base.HAMException;

public class MediaPlanRegisterManager {

    /** 共通コード定義のコードタイプ(期検索用) */
    private static final String COMMON_CODE_TYPE_TERM = "14";

    /** シングルトンインスタンス */
    private static MediaPlanRegisterManager _manager = new MediaPlanRegisterManager();

    private MediaPlanRegisterVO _vo;

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private MediaPlanRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static MediaPlanRegisterManager getInstance() {
        return _manager;
    }

    public void MediaPlanRegister(MediaPlanRegisterVO vo) throws HAMException {
        _vo = vo;

        //登録用DAOを呼びだす．
        MediaPlanRegisterDAO mediaplanregdao = MediaPlanRegisterDAOFactory.createCampaignRegisterDetailsDAO();

        //排他チェック．
        if (!exclusionCheck()) {
            throw new HAMException("排他エラー", "BJ-E0005");
        }

        //削除.
        if (vo.getDelVo() != null && !vo.getDelVo().equals("")) {

            //削除用VOを1行ずつ取得する．
            for (Tbj01MediaPlanVO delvo : vo.getDelVo()) {
                //セットしたものを登録用DAOの削除メソッドに渡す．
                mediaplanregdao.delMediaPlan(delvo);

                //対象の媒体状況管理Noについて、キャンペーン一覧・詳細データを更新
                updateCampaign(delvo);
            }
        }

        //登録
        if (vo.getInsVo() != null && !vo.getInsVo().equals("")) {

            //登録用VOを1行ずつ取得する．
            for (Tbj01MediaPlanVO insvo : vo.getInsVo()) {

                //---------------------媒体状況管理NOを取得する為の処理-----------------//
                //DAOを呼びだす．
                Tbj01MediaPlanDAO mediaplanfinddao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
                //結果用VOListに媒体管理NoのMAX値をセットする．
                List<Tbj01MediaPlanVO> result = mediaplanfinddao.findMediaPlanMaxCd();
                //登録用VOの媒体管理Noに、結果用VOListの媒体管理No+1をセットする．
                insvo.setMEDIAPLANNO(result.get(0).getMEDIAPLANNO().add(BigDecimal.valueOf(1)));
                //---------------------媒体状況管理NOを取得する為の処理-----------------//

                //---------------------費用計画NOを取得する為の処理-----------------//
                //結果用VOListに、取得した費用計画Noをセットする.
                List<Mbj09HiyouVO> hiyouresult = getInsertHiyou(insvo);
                //費用計画Noが空の場合はnullをセット.
                if (hiyouresult.isEmpty())
                {
                    insvo.setHIYOUNO(null);
                }
                else
                {
                    insvo.setHIYOUNO(hiyouresult.get(0).getHIYOUNO());
                }
                //---------------------費用計画NOを取得する為の処理-----------------//

                //以下登録
                mediaplanregdao.insMediaPlan(insvo);

                //対象の媒体状況管理Noについて、キャンペーン一覧・詳細データを更新
                updateCampaign(insvo);

            }
        }

        //更新
        if (vo.getUpdVo() != null && !vo.getUpdVo().equals("")) {

            for (Tbj01MediaPlanVO updvo : vo.getUpdVo()) {

                //---------------------費用計画NOを取得する為の処理-----------------//
               //結果用VOListに、取得した費用計画Noをセットする.
                List<Mbj09HiyouVO> hiyouresult = getInsertHiyou(updvo);

                //費用計画Noが空の場合はnullをセット.
                if (hiyouresult.isEmpty())
                {
                    updvo.setHIYOUNO(null);
                }
                else
                {
                    updvo.setHIYOUNO(hiyouresult.get(0).getHIYOUNO());
                }
                //---------------------費用計画NOを取得する為の処理-----------------//

                Tbj01MediaPlanDAO mpdao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
                Tbj01MediaPlanCondition mpcond = new Tbj01MediaPlanCondition();
                mpcond.setMediaplanno(updvo.getMEDIAPLANNO());
                List<Tbj01MediaPlanVO> mpVoList = mpdao.findMediaPlanByMediaPlanNo(mpcond);
                Tbj01MediaPlanVO mpVo = mpVoList.get(0);

                if (mpVo.getCAMPCD().equals(updvo.getCAMPCD()))
                {
                    //キャンペーンコードが変更されていない場合は、UPDATE
                    mediaplanregdao.updMediaPlan(updvo);
                }
                else
                {
                    //キャンペーンコードが変更されている場合は、DELETE/INSERT
                    mediaplanregdao.delMediaPlan(mpVo);
                    updateCampaign(mpVo);
                    mediaplanregdao.delinsMediaPlan(updvo);
                }

                //対象の媒体状況管理Noについて、キャンペーン一覧・詳細データを更新
                updateCampaign(updvo);
            }
        }
    }

    /**
     * キャンペーン一覧・キャンペーン詳細のデータを更新
     * @param mediavo 媒体状況管理データ
     * @throws HAMException
     */
    private void updateCampaign(Tbj01MediaPlanVO mediavo) throws HAMException {

        CampaignRegisterDAO campRegistDAO = CampaignRegisterDAOFactory.createCampaignRegisterDAO();
        CampaignRegisterDetailsDAO campDetailRegistDAO = CampaignRegisterDetailsDAOFactory.createCampaignRegisterDetailsDAO();

        //更新対象のキャンペーン一覧データの取得
        Tbj12CampaignDAO campdao = Tbj12CampaignDAOFactory.createTbj12CampaignDAO();
        List<Tbj12CampaignVO> campvolist = campdao.findCampaignListByCampCd(mediavo.getCAMPCD());
        Tbj12CampaignVO campvo = campvolist.get(0);

        //更新用のキャンペーンVOを作成
        campvo = updateCampaignVO(mediavo,campvo);

        //キャンペーンデータを更新
        campRegistDAO.updCampaignList(campvo);

        Tbj13CampDetailCondition campcond = new Tbj13CampDetailCondition();
        campcond.setCampcd(mediavo.getCAMPCD());

        //更新対象のキャンペーン詳細データを一度削除しておく
        campDetailRegistDAO.delCampaignDetailsByCd(campcond);

        List<Tbj13CampDetailVO> campdetailvo = createCampDetailVO(mediavo);

        if (campdetailvo != null) {
            for (Tbj13CampDetailVO insvo : campdetailvo) {
                campDetailRegistDAO.insCampaignDetails(insvo);
            }
        }
    }

    /**
     * キャンペーンデータ更新用VOの作成
     * （紐づくキャンペーンデータが見つかった場合のみ実施）
     * @param mediavo 媒体管理VO
     * @param campvo キャンペーンVO
     * @return 更新用VO
     * @throws HAMException
     */
    private Tbj12CampaignVO updateCampaignVO(Tbj01MediaPlanVO mediavo,Tbj12CampaignVO campvo) throws HAMException {

        //対象のキャンペーンコードを持つ媒体状況管理データの合計を取得
        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanByCampCdSUM(campvo.getCAMPCD());
        List<Tbj01MediaPlanVO> mediaflgvolist = mediadao.findMediaPlanByCampCd(mediavo.getCAMPCD());

        if (mediavolist.size() == 1) {
            //取得できた時は取得したデータを入れてあげる
            Tbj01MediaPlanVO summediavo = mediavolist.get(0);

            //予算と実績をvoに入れる
            campvo.setACTUAL(summediavo.getACTUAL());
            campvo.setACTUALHM(summediavo.getACTUALHM());
            campvo.setBUDGET(summediavo.getBUDGET());
            campvo.setBUDGETHM(summediavo.getBUDGETHM());
            campvo.setBAITAIFLG("1");
        }
        if (mediaflgvolist.size() == 0) {
            //キャンペーンコードで媒体状況管理を検索し、
            //データがなければvoに0を入れる
            campvo.setBAITAIFLG(String.valueOf(0));
        }

        return campvo;
    }

    /**
     * 登録用キャンペーン詳細データを作成
     * （Delete→Insertするので、必ず全データを作成）
     * @param mediavo
     * @return
     * @throws HAMException
     */
    private List<Tbj13CampDetailVO> createCampDetailVO(Tbj01MediaPlanVO mediavo) throws HAMException {
        List<Tbj13CampDetailVO> campdetailvo = new ArrayList<Tbj13CampDetailVO>();

        Tbj01MediaPlanDAO mediadao = Tbj01MediaPlanDAOFactory.createTbj01MediaPlanDAO();
        List<Tbj01MediaPlanVO> resistList = mediadao.findMediaPlanByCampCdDist(mediavo.getCAMPCD());

        for (Tbj01MediaPlanVO vo : resistList)
        {
            //期間とキャンペーンコードと媒体で検索し、見つかったデータの合計値を取得

            Tbj01MediaPlanCondition mediacond = new Tbj01MediaPlanCondition();
            mediacond.setCampcd(vo.getCAMPCD());
            mediacond.setYoteiym(vo.getYOTEIYM());
            mediacond.setMediacd(vo.getMEDIACD());
            List<Tbj01MediaPlanVO> mediavolist = mediadao.findMediaPlanSUMByCdAndMonth(mediacond);
            List<Tbj01MediaPlanVO> mediavolists = mediadao.findMediaPlanByCampCd(vo.getCAMPCD());

            //見つからなかった時（削除した時など）はnullとしておく
            if (mediavolists.size() == 0) {
                campdetailvo = null;
            } else {
                //ある時は登録用データを作成

                Tbj01MediaPlanVO summediavo = mediavolist.get(0);
                Tbj13CampDetailVO addvo = new Tbj13CampDetailVO();

                addvo.setCAMPCD(vo.getCAMPCD());
                addvo.setDCARCD(mediavo.getDCARCD());
                addvo.setMEDIACD(vo.getMEDIACD());
                addvo.setPHASE(mediavo.getPHASE());
                addvo.setYOTEIYM(vo.getYOTEIYM());
                addvo.setKIKANFROM(vo.getKIKANFROM());
                addvo.setKIKANTO(vo.getKIKANTO());
                addvo.setBUDGET(summediavo.getBUDGET());
                addvo.setBUDGETHM(summediavo.getBUDGETHM());
                addvo.setCRTAPL(mediavo.getCRTAPL());
                addvo.setCRTNM(mediavo.getCRTNM());
                addvo.setCRTID(mediavo.getCRTID());
                addvo.setUPDNM(mediavo.getUPDNM());
                addvo.setUPDAPL(mediavo.getUPDAPL());
                addvo.setUPDID(mediavo.getUPDID());

                campdetailvo.add(addvo);
            }
        }

        return campdetailvo;
    }

    /**
     * 更新・登録対象voの費用計画情報を取得
     * @param vo 更新・登録対象vo
     * @return 費用計画情報
     * @throws HAMException
     */
    private List<Mbj09HiyouVO> getInsertHiyou(Tbj01MediaPlanVO vo) throws HAMException
    {
        //費用計画Noの取得
        Mbj09HiyouDAO hiyodao = Mbj09HiyouDAOFactory.createMbj09HiyouDAO();
        Mbj09HiyouCondition hiyocond = new Mbj09HiyouCondition();
        hiyocond.setDcarcd(vo.getDCARCD());
        hiyocond.setMediacd(vo.getMEDIACD());
        hiyocond.setPhase(vo.getPHASE());
        hiyocond.setTerm(convertTerm2Code(vo.getTERM()));
        List<Mbj09HiyouVO> hiyoresult =hiyodao.selectVO(hiyocond);

        return hiyoresult;
    }

    /**
     * コードマスタから期の文字列に対応したコードに変換する
     * @param str 期の文字列(上/下)
     * @return 変換したコード
     */
    private String convertTerm2Code(String str) {
        // コードマスタから期⇒数字に変換する
        String retVal = "";
        Mbj12CodeDAO dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition cond = new Mbj12CodeCondition();
        cond.setCodetype(COMMON_CODE_TYPE_TERM);
        cond.setCodename(str);
        try {
            List<Mbj12CodeVO> result = dao.selectVO(cond);
            if (!result.isEmpty()) {
                Mbj12CodeVO vo = result.get(0);
                retVal = vo.getKEYCODE();
            }
        } catch (HAMException e) {
            // 失敗した場合は何もしない
        }

        return retVal;
    }

    /**
     * 排他チェックを行います
     * @return チェック結果
     * @throws HAMException
     */
    private boolean exclusionCheck() throws HAMException {

        //再検索
        FindMediaPlanDAO dao = FindMediaPlanDAOFactory.createFindMediaPlanDAO();
        FindMediaPlanCondition toCond = new FindMediaPlanCondition();

        //条件を設定する．
        toCond.setDcarcd(_vo.getDcarCd());
        toCond.setPhase(_vo.getPhase());
        toCond.setHamid(_vo.getHamId());

        List<FindMediaPlanVO> list = dao.findMediaPlanByCond(toCond);

        // 比較を簡略化するために、HashMapに型を変換
        HashMap<BigDecimal, Date> hm = new HashMap<BigDecimal, Date>();
        for (FindMediaPlanVO mpVo : list) {
            hm.put(mpVo.getMEDIAPLANNO(), mpVo.getUPDDATE());
        }

        boolean error = false;

        //更新対象排他チェック
        if (_vo.getUpdVo() != null && _vo.getUpdVo().size() > 0) {
            for (Tbj01MediaPlanVO mpVo : _vo.getUpdVo()) {
                if (!hm.containsKey(mpVo.getMEDIAPLANNO())) {
                    error = true;
                    break;
                }

                if (_vo.getLatestDate().before(hm.get(mpVo.getMEDIAPLANNO()))) {
                    error = true;
                    break;
                }
            }

            if (error) {
                return false;
            }
        }

        //削除対象排他チェック
        if (_vo.getDelVo() != null && _vo.getDelVo().size() > 0) {
            for (Tbj01MediaPlanVO mpVo : _vo.getDelVo()) {
                if (!hm.containsKey(mpVo.getMEDIAPLANNO())) {
                    error = true;
                    break;
                }

                if (_vo.getLatestDate().before(hm.get(mpVo.getMEDIAPLANNO()))) {
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
