package jp.co.isid.ham.production.model;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu07SikKrSprdVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcCondition;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu29CcVO;
import jp.co.isid.ham.common.model.RepaVbjaMeu2FHmokDAO;
import jp.co.isid.ham.common.model.RepaVbjaMeu2FHmokDAOFactory;
import jp.co.isid.ham.common.model.RepaVbjaMeu2FHmokVO;
import jp.co.isid.ham.common.model.Vbj01AccUserCondition;
import jp.co.isid.ham.common.model.Vbj01AccUserDAO;
import jp.co.isid.ham.common.model.Vbj01AccUserDAOFactory;
import jp.co.isid.ham.common.model.Vbj01AccUserVO;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.StringUtil;

/**
 * <P>
 * チェックリスト用のManager
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
public class CheckListManager {

    /** シングルトンインスタンス */
    private static CheckListManager _manager = new CheckListManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private CheckListManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static CheckListManager getInstance() {
        return _manager;
    }

    /**
     * チェックリスト出力画面の初期データ取得処理を行う
     * @param cond
     * @return
     * @throws HAMException
     */
    public GetIniDataForCheckListResult getIniDataForCheckList(GetIniDataForCheckListCondition cond) throws HAMException {
        GetIniDataForCheckListResult result = new GetIniDataForCheckListResult();

        //対象得意先の取得
        Mbj12CodeDAO codeDao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("32");
        List<Mbj12CodeVO> codeVoList = codeDao.selectVO(codeCond);

        CheckListDAO thsKgyDao = CheckListDAOFactory.createCheckListDAO();
        CheckListThsDataVO thsKgyCond = new CheckListThsDataVO();
        List<CheckListThsDataVO> thsKgyVoList = new ArrayList<CheckListThsDataVO>();
        for (Mbj12CodeVO mbj12CodeVo : codeVoList) {
            String[] thsCd = mbj12CodeVo.getKEYCODE().split("-");
            thsKgyCond.setTHSKGYCD(thsCd[0]);
            thsKgyCond.setSEQNO(thsCd[1]);
            thsKgyCond.setENDYMD(cond.getBaseDate());
            thsKgyCond.setSTARTYMD(cond.getBaseDate());
            thsKgyVoList.addAll(thsKgyDao.findCheckListTHS(thsKgyCond));
        }
        result.setCheckListThsDataVoList(thsKgyVoList);

//不要
//        //発注局の取得
//        codeCond = new Mbj12CodeCondition();
//        codeCond.setCodetype("31");
//        codeVoList.addAll(codeDao.selectVO(codeCond));

        result.setMbj12CodeVoList(codeVoList);

        return result;
    }

    /**
     * 担当者に表示する値のリストを取得する
     * @param cond
     * @return
     * @throws HAMException
     */
    public FindCheckListTantoResult findCheckListTanto(FindCheckListTantoCondition cond) throws HAMException {
        FindCheckListTantoResult result = new FindCheckListTantoResult();

        CheckListECDAO ecDao = CheckListECDAOFactory.createCheckListECDAO();
        CheckListDAO hamDao = CheckListDAOFactory.createCheckListDAO();

//        //*********************************
//        //業務会計DBから発注局を取得
//        //*********************************
//        List<FindCheckListHattyuKykVO> voKykList = ecDao.findCheckListHattyuKyk(cond);
//        result.setFindCheckListHattyuKykVoList(voKykList);

        //*********************************
        //業務会計DBから担当者のID、依頼先組織コードを取得
        //*********************************
        List<FindCheckListTantoVO> voList = ecDao.findCheckListListData(cond);

        Map<String, FindCheckListTantoVO> tantoVoMap = new HashMap<String, FindCheckListTantoVO>();
        //★Map<String, FindCheckListHattyuKykVO> hattyuKykVoMap = new HashMap<String, FindCheckListHattyuKykVO>();
        List<String> iraisakiCdList = new ArrayList<String>();
        Vbj01AccUserDAO accUserDao = Vbj01AccUserDAOFactory.createVbj01AccUserDAO();
        for (int i = 0; i < voList.size(); i++) {
            //*********************************
            //取得した担当者IDから名称を取得
            //*********************************
            //取得済みの担当者IDの場合は処理をしない
            if (!tantoVoMap.containsKey(voList.get(i).getEGTNTCD())) {
                FindCheckListTantoVO addVo = new FindCheckListTantoVO();
                Vbj01AccUserCondition accUserCond = new Vbj01AccUserCondition();
                accUserCond.setEsqid(voList.get(i).getEGTNTCD());
                List<Vbj01AccUserVO> accUserVoList = accUserDao.selectByEsqId5(accUserCond);
                if (accUserVoList.size() > 0) {
                    addVo.setEGTNTCD(voList.get(i).getEGTNTCD());
                    addVo.setCN(accUserVoList.get(0).getCN());
                    addVo.setIRAISSIKCD(voList.get(i).getIRAISSIKCD());
                }
                tantoVoMap.put(voList.get(i).getEGTNTCD(), addVo);
            }

            //*********************************
            //局コード、名称を取得するコードを保持
            //*********************************
            //取得済みのコードの場合は処理をしない
            if (!iraisakiCdList.contains(voList.get(i).getIRAISSIKCD())) {
                iraisakiCdList.add(voList.get(i).getIRAISSIKCD());
            }
        }

        //Mapに格納したVoをListに格納しなおしてResultクラスへ
        List<FindCheckListTantoVO> findCheckListTantoVoList = new ArrayList<FindCheckListTantoVO>();
        for (Map.Entry<String, FindCheckListTantoVO> e : tantoVoMap.entrySet()) {
            if (!StringUtil.isBlank(e.getValue().getCN())) {
                findCheckListTantoVoList.add(e.getValue());
            }
        }
        result.setFindCheckListTantoVoList(findCheckListTantoVoList);

        //*********************************
        //局コード、名称を取得(依頼先コードはカンマ区切りで取得)
        //*********************************
        if (iraisakiCdList != null && iraisakiCdList.size() > 0) {
            RepaVbjaMeu07SikKrSprdCondition meu07SikKrSprdCond = new RepaVbjaMeu07SikKrSprdCondition();
            meu07SikKrSprdCond.setStartymd(cond.getEigyobi());
            meu07SikKrSprdCond.setEndymd(cond.getEigyobi());
            StringBuffer sikCds = new StringBuffer();
            for (int i = 0; i < iraisakiCdList.size(); i++) {
                if (i > 0) {
                    sikCds.append(", ");
                }
                sikCds.append("'");
                sikCds.append(iraisakiCdList.get(i));
                sikCds.append("'");
            }
            meu07SikKrSprdCond.setSikcd(sikCds.toString());
            result.setFindCheckListHattyuKykVoList(hamDao.findCheckListHATKYK(meu07SikKrSprdCond));
        }

        return result;
    }

    public GetRepDataForChkListResult GetRepDataForChkList(GetRepDataForChkListCondition cond) throws HAMException {
        GetRepDataForChkListResult result = new GetRepDataForChkListResult();

        //********************************
        //業務会計側データの取得
        //********************************
        CheckListECDAO ecDao = CheckListECDAOFactory.createCheckListECDAO();
        List<RepDataForChkListR3VO> repDataForChkListR3 = ecDao.findCheckListREPDATA(cond);
        //個人情報VIEWから担当者名を取得して名称を補完
        Map<String, Vbj01AccUserVO> tantoVoMap = new HashMap<String, Vbj01AccUserVO>();
        Vbj01AccUserDAO accUserDao = Vbj01AccUserDAOFactory.createVbj01AccUserDAO();
        for (int i = 0; i < repDataForChkListR3.size(); i++) {
            //*********************************
            //取得した担当者IDから名称を取得
            //*********************************
            //取得済みの担当者IDの場合は検索をしない
            Vbj01AccUserVO accUserVo = null;
            if (!tantoVoMap.containsKey(repDataForChkListR3.get(i).getEGTNTCD())) {
                Vbj01AccUserCondition accUserCond = new Vbj01AccUserCondition();
                accUserCond.setEsqid(repDataForChkListR3.get(i).getEGTNTCD());
                List<Vbj01AccUserVO> accUserVoList = accUserDao.selectByEsqId5(accUserCond);
                if (accUserVoList.size() > 0) {
                    accUserVo = accUserVoList.get(0);
                }
                tantoVoMap.put(repDataForChkListR3.get(i).getEGTNTCD(), accUserVo);
            } else {
                accUserVo = tantoVoMap.get(repDataForChkListR3.get(i).getEGTNTCD());
            }
            if (accUserVo != null) {
                repDataForChkListR3.get(i).setEGTNTNM(accUserVo.getCN());
            }
        }
        result.setRepDataForChkListR3(repDataForChkListR3);

        //********************************
        //HAM側データの取得
        //********************************
        CheckListDAO hamDao = CheckListDAOFactory.createCheckListDAO();
        List<RepDataForChkListHAMVO> repDataForChkListHAM = hamDao.findCheckListREPDATA(cond);
        result.setRepDataForChkListHAM(repDataForChkListHAM);

        //経理組織展開テーブル
        RepaVbjaMeu07SikKrSprdDAO meu07SikKrSprdDao = RepaVbjaMeu07SikKrSprdDAOFactory.createRepaVbjaMeu07SikKrSprdDAO();
        RepaVbjaMeu07SikKrSprdVO meu07SikKrSprdVo = new RepaVbjaMeu07SikKrSprdVO();
        //meu07SikKrSprdVo.setSIKCD(voList.get(i).getIRAISSIKCD());
        meu07SikKrSprdVo.setSTARTYMD(cond.getEigyobi());
        meu07SikKrSprdVo.setENDYMD(cond.getEigyobi());
        List<RepaVbjaMeu07SikKrSprdVO> meu07SikKrSprdVoList = meu07SikKrSprdDao.selectVoByDate(meu07SikKrSprdVo);
        result.setRepaVbjaMeu07SikKrSprd(meu07SikKrSprdVoList);

        //費目マスタ
        RepaVbjaMeu2FHmokDAO meu2FHmokDao = RepaVbjaMeu2FHmokDAOFactory.createRepaVbjaMeu2FHmokDAO();
        RepaVbjaMeu2FHmokVO meu2FHmokVo = new RepaVbjaMeu2FHmokVO();
        //meu07SikKrSprdVo.setSIKCD(voList.get(i).getIRAISSIKCD());
        meu2FHmokVo.setHKYMD(cond.getEigyobi());
        meu2FHmokVo.setHAISYMD(cond.getEigyobi());
        List<RepaVbjaMeu2FHmokVO> meu2FHmokVoList = meu2FHmokDao.selectVoByDate(meu2FHmokVo);
        result.setRepaVbjaMeu2FHmok(meu2FHmokVoList);


        //税区分／名称の取得
        RepaVbjaMeu29CcDAO meu29CcDao = RepaVbjaMeu29CcDAOFactory.createRepaVbjaMeu29CcDAO();
        RepaVbjaMeu29CcCondition meu29CcCond = new RepaVbjaMeu29CcCondition();
        meu29CcCond.setKycdknd("MA");
        meu29CcCond.setHaisymd("99999999");
        List<RepaVbjaMeu29CcVO> meu29CcVoList = meu29CcDao.selectVO(meu29CcCond);
        result.setRepaVbjaMeu29Cc(meu29CcVoList);

        return result;
    }

}
