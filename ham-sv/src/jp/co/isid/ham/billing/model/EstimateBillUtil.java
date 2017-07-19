package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.Mbj26BillGroupVO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailCondition;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAO;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailDAOFactory;
import jp.co.isid.ham.common.model.Tbj06EstimateDetailVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 見積書・請求書に関するユーティリティクラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/09/11 HLC S.Fujimoto)<BR>
 * ・請求業務変更対応(2016/02/04 HLC K.Soga)<BR>
 * ・HDX対応(2016/04/20 HLC K.Soga)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.billing.ham.isid.co.jp/")
@XmlType(namespace = "http://model.billing.ham.isid.co.jp/")
public class EstimateBillUtil {

    /**
     * HC部門コード(Fee案件請求用)取得
     * MAP格納用
     * @return 検索結果
     * @throws HAMException
     */
    public static List<Mbj26BillGroupVO> getHCBumonCdBillList(String groupCd) throws HAMException {

        Mbj26BillGroupDAO mbj26Dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        List<Mbj26BillGroupVO> voList = new ArrayList<Mbj26BillGroupVO>();
        voList = mbj26Dao.selectBillGroupVO(groupCd);

        return voList;
    }

    /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
    /**
     * HC部門コード(Fee案件請求用)取得
     * @return 検索結果
     * @throws HAMException
     */
    public static List<Mbj26BillGroupVO> getBillList(String groupCd) throws HAMException {

        //請求グループマスタ
        Mbj26BillGroupDAO mbj26Dao = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        List<Mbj26BillGroupVO> voList = new ArrayList<Mbj26BillGroupVO>();
        voList = mbj26Dao.selectHCBumonBillGroupVO(groupCd);

        return voList;
    }
    /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */

    /**
     * HM請求書(見積明細出力順SEQNO)集計キー取得
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public static List<FindHMBillSeqNoVO> getHMBillSeqNoSummary(FindHMBillSeqNoCondition condition) throws HAMException {

        //HM請求書(見積明細出力順SEQNO)取得検索DAO
        FindHMBillSeqNoDAO dao = FindHCEstimateCreationDAOFactory.createFindHMBillDetailSeqNoDao();
        FindHMBillSeqNoCondition cond = new FindHMBillSeqNoCondition();

        cond.setPhase(condition.getPhase());
        cond.setYearMonth(condition.getYearMonth());

        /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
        cond.setGroupCd(condition.getGroupCd());
        cond.setHcbumoncdbill(condition.getHcbumoncdbill());
        //制作
        if(cond.getGroupCd() != null){
            cond.setGroupCd(condition.getGroupCd());
        //媒体
        }else{
            cond.setGroupCd(HAMConstants.GROUPCODE0);
        }
        /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */

        return dao.selectSummaryVO(cond);
    }

    /**
     * 請求先グループ出力順SEQNO更新
     * @param voList List<FindHMBillSeqNoVO> HM請求書(見積明細出力順SEQNO)集計キー
     * @param map HashMap<String, BigDecimal> 請求グループマップ
     * @return 正常終了(true)/異常終了(false)
     * @throws HAMException
     */
    public static boolean updateHCBumonCdBill(List<FindHMBillSeqNoVO> voList, HashMap<String, BigDecimal> map, BigDecimal estSeqNo, String mediaProduction) throws HAMException {

        //SEQNO初期設定
        BigDecimal seqNo = BigDecimal.valueOf(0);

        try {
            //SeqNoから最大値を取得
            for (int i = 0; i < voList.size(); i++) {

                //1行取得
                FindHMBillSeqNoVO vo = voList.get(i);

                //請求先グループがNullでない場合
                if (vo.getHCBUMONCDBILL() != null && vo.getHCBUMONCDBILL().trim().length() != 0 &&
                        vo.getMBJ26HCBUMONCDBILL() != null && vo.getMBJ26HCBUMONCDBILL().trim().length() != 0) {

                    //請求グループマップ内の最大値より大きい場合に格納
                    if (map.get(vo.getHCBUMONCDBILL()).compareTo(vo.getHCBUMONCDBILLSEQNO()) < 0) {
                        map.put(vo.getHCBUMONCDBILL(), vo.getHCBUMONCDBILLSEQNO());
                    }
                }
            }

            //SeqNo付与
            for (int i = 0; i < voList.size(); i++) {

                /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
                //見積SEQNOが同一の場合
                if(voList.get(i).getESTSEQNO().equals(estSeqNo)){
                /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */

                    //1行取得
                    FindHMBillSeqNoVO vo = voList.get(i);

                    //見積種別が媒体、出力グループの1桁目が[1]の場合
                    if(mediaProduction.equals(HAMConstants.MEDIA) && vo.getOUTPUTGROUP().substring(0, 1).equals(HAMConstants.ONE)){
                        //取得したVOで、請求先グループマスタの請求先グループを取得
                        seqNo = map.get(vo.getMBJ26HCBUMONCDBILL());

                        //請求先グループがNullの場合
                        if (vo.getHCBUMONCDBILL() == null || vo.getHCBUMONCDBILL().trim().length() == 0) {
                            vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                            vo.setUPDATEFLG(BigDecimal.valueOf(1));
                            vo.setHCBUMONCDBILLSEQNO(seqNo.add(BigDecimal.valueOf(1)));
                            map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));

                            /** 2016/02/04 請求業務変更対応 HLC K.Soga DEL Start */
                            //map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));
                            /** 2016/02/04 請求業務変更対応 HLC K.Soga DEL End */

                            //請求先グループがNullでない場合
                        } else {

                            //見積明細の請求先グループ≠請求先グループマスタの請求先グループの場合
                            if (!vo.getHCBUMONCDBILL().equals(vo.getMBJ26HCBUMONCDBILL())) {
                                vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                                vo.setHCBUMONCDBILLSEQNO(seqNo.add(BigDecimal.valueOf(1)));
                                map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));
                            }
                        }
                    }

                    /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
                    //見積種別が制作の場合
                    if(mediaProduction.equals(HAMConstants.PRODUCTION)){

                        //初期設定
                        Boolean flg = false;

                        //取得したVOで、請求先グループマスタの請求先グループを取得
                        seqNo = map.get(vo.getMBJ26HCBUMONCDBILL());

                        //請求先グループがNullの場合
                        vo.setUPDATEFLG(BigDecimal.valueOf(1));
                        vo.setESTDETAILSEQNO(voList.get(i).getESTDETAILSEQNO());
                        vo.setOUTPUTGROUP(voList.get(i).getOUTPUTGROUP());

                        //既に存在する出力グループがある場合、その出力グループを設定
                        for (int j = 0; j < voList.size(); j++) {
                            if(i != 0 && voList.get(i).getOUTPUTGROUP().equals(voList.get(j).getOUTPUTGROUP())
                                    && !(voList.get(i).getESTDETAILSEQNO() == voList.get(j).getESTDETAILSEQNO())
                                    && voList.get(j).getUPDATEFLG() == BigDecimal.valueOf(1)){
                                //取得したVOで、請求先グループマスタの請求先グループを取得
                                vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                                vo.setHCBUMONCDBILLSEQNO(voList.get(j).getHCBUMONCDBILLSEQNO());
                                flg = true;
                            }
                        }
                        if(!flg && (vo.getHCBUMONCDBILL() == null || vo.getHCBUMONCDBILL().trim().length() == 0))
                        {
                            vo.setHCBUMONCDBILL(vo.getMBJ26HCBUMONCDBILL());
                            vo.setHCBUMONCDBILLSEQNO(seqNo.add(BigDecimal.valueOf(1)));
                            map.put(vo.getMBJ26HCBUMONCDBILL(), seqNo.add(BigDecimal.valueOf(1)));
                        }
                    /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */
                    }
                }
            }

            //見積明細更新
            Tbj06EstimateDetailDAO tbj06Dao = Tbj06EstimateDetailDAOFactory.createTbj06EstimateDetailDAO();
            Tbj06EstimateDetailCondition tbj06Cond = new Tbj06EstimateDetailCondition();

            //取得した見積明細分ループ処理
            for (int i = 0; i < voList.size(); i++) {
                FindHMBillSeqNoVO vo = voList.get(i);

                //媒体の場合
                if(mediaProduction.equals(HAMConstants.MEDIA) && vo.getOUTPUTGROUP().substring(0, 1).equals(HAMConstants.ONE)){
                    //更新フラグが[1]、出力グループコードがnullの場合
                    if(vo.getUPDATEFLG().equals(BigDecimal.valueOf(1))) {
                        tbj06Cond.setPhase(vo.getPHASE());
                        tbj06Cond.setCrdate(vo.getCRDATE());
                        tbj06Cond.setEstseqno(vo.getESTSEQNO());
                        tbj06Cond.setOutputgroup(vo.getOUTPUTGROUP());

                        /** 2016/02/04 請求業務変更対応 HLC K.Soga MOD Start */
                        //List<Tbj06EstimateDetailVO> tbj06VoList = tbj06Dao.selectVO(tbj06Cond);
                        List<Tbj06EstimateDetailVO> tbj06VoList = tbj06Dao.findBillSeqNoVO(tbj06Cond);
                        /** 2016/02/04 請求業務変更対応 HLC K.Soga MOD End */

                        //見積明細件数分ループ処理
                        for (int j = 0; j < tbj06VoList.size(); j++) {
                            Tbj06EstimateDetailVO tbj06SelectVo = tbj06VoList.get(j);

                            //更新
                            Tbj06EstimateDetailVO tbj06Vo = new Tbj06EstimateDetailVO();
                            tbj06Vo.setESTDETAILSEQNO(tbj06SelectVo.getESTDETAILSEQNO());
                            tbj06Vo.setHCBUMONCDBILL(vo.getHCBUMONCDBILL());
                            tbj06Vo.setHCBUMONCDBILLSEQNO(vo.getHCBUMONCDBILLSEQNO());
                            tbj06Vo.setCRTDATE(tbj06SelectVo.getCRDATE());
                            tbj06Vo.setCRTNM(tbj06SelectVo.getCRTNM());
                            tbj06Vo.setCRTAPL(tbj06SelectVo.getCRTAPL());
                            tbj06Vo.setCRTID(tbj06SelectVo.getCRTID());
                            tbj06Vo.setUPDNM(tbj06SelectVo.getUPDNM());
                            tbj06Vo.setUPDAPL(tbj06SelectVo.getUPDAPL());
                            tbj06Vo.setUPDID(tbj06SelectVo.getUPDID());
                            tbj06Dao.updateVO(tbj06Vo);
                        }
                    }
                }

                /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD Start */
                //制作の場合
                if(mediaProduction.equals(HAMConstants.PRODUCTION) ){
                    //更新フラグが[1]の場合
                    if(vo.getUPDATEFLG() == BigDecimal.valueOf(1)) {
                        tbj06Cond.setPhase(vo.getPHASE());
                        tbj06Cond.setCrdate(vo.getCRDATE());
                        tbj06Cond.setEstseqno(vo.getESTSEQNO());
                        tbj06Cond.setOutputgroup(vo.getOUTPUTGROUP());
                        List<Tbj06EstimateDetailVO> tbj06VoList = tbj06Dao.findBillSeqNoVO(tbj06Cond);

                        //見積明細件数分ループ処理
                        for (int j = 0; j < tbj06VoList.size(); j++) {
                            Tbj06EstimateDetailVO tbj06SelectVo = tbj06VoList.get(j);

                            //見積明細管理NOが同値の場合
                            if(tbj06SelectVo.getESTDETAILSEQNO().equals(vo.getESTDETAILSEQNO())){
                                //更新
                                Tbj06EstimateDetailVO tbj06Vo = new Tbj06EstimateDetailVO();
                                tbj06Vo.setESTDETAILSEQNO(tbj06SelectVo.getESTDETAILSEQNO());
                                tbj06Vo.setHCBUMONCDBILL(vo.getHCBUMONCDBILL());
                                tbj06Vo.setHCBUMONCDBILLSEQNO(vo.getHCBUMONCDBILLSEQNO());
                                tbj06Vo.setCRTDATE(tbj06SelectVo.getCRDATE());
                                tbj06Vo.setCRTNM(tbj06SelectVo.getCRTNM());
                                tbj06Vo.setCRTAPL(tbj06SelectVo.getCRTAPL());
                                tbj06Vo.setCRTID(tbj06SelectVo.getCRTID());
                                tbj06Vo.setUPDNM(tbj06SelectVo.getUPDNM());
                                tbj06Vo.setUPDAPL(tbj06SelectVo.getUPDAPL());
                                tbj06Vo.setUPDID(tbj06SelectVo.getUPDID());
                                tbj06Dao.updateVO(tbj06Vo);
                            }
                        }
                    }
                /** 2016/02/04 請求業務変更対応 HLC K.Soga ADD End */
                }
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }

        return true;
    }
}
