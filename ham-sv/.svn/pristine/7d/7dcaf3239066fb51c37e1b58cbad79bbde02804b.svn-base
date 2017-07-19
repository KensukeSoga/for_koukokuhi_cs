package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * 起動処理管理
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/12 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class StartUpManager {

    /** シングルトンインスタンス */
    private static StartUpManager _manager = new StartUpManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private StartUpManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static StartUpManager getInstance() {
        return _manager;
    }

    /**
     * 開始処理
     * @param mbj12cond
     * @param tbj29vo
     * @return
     * @throws HAMException
     */
    public StartUpResult startUp(StartUpCondition startupcond) throws HAMException {

        StartUpResult result = new StartUpResult();

        // 担当者マスタを取得
        Mbj02UserDAO mbj02dao = Mbj02UserDAOFactory.createMbj02UserDAO();
        Mbj02UserCondition mbj02cond = new Mbj02UserCondition();
        mbj02cond.setHamid(startupcond.getHamid());
        List<Mbj02UserVO> mbj02list = mbj02dao.selectVO(mbj02cond);
        result.setUserList(mbj02list);

        // コードマスタ(フェイズ)を取得
        Mbj12CodeDAO mbj12dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition mbj12condphase = new Mbj12CodeCondition();
        mbj12condphase.setCodetype(startupcond.getCodetypePhase());
        List<Mbj12CodeVO> mbj12list = mbj12dao.selectVO(mbj12condphase);

        // コードマスタ(帳票ディレクトリ)を取得
        Mbj12CodeCondition mbj12condreport = new Mbj12CodeCondition();
        mbj12condreport.setCodetype(startupcond.getCodetypeReport());
        mbj12list.addAll(mbj12dao.selectVO(mbj12condreport));

        result.setCodeList(mbj12list);

        String usrNm = " ";
        if (mbj02list != null && mbj02list.size() > 0) {
            usrNm = mbj02list.get(0).getUSERNAME1() + mbj02list.get(0).getUSERNAME2();
        }

        if (startupcond.getCreateLoginInfo()) {
            // ログインユーザー登録(DELETE後にINSERT)
            Tbj29LoginUserDAO dao = Tbj29LoginUserDAOFactory.createTbj29LoginUserDAO();
            Tbj29LoginUserCondition tbj29cond = new Tbj29LoginUserCondition();
            tbj29cond.setHamid(startupcond.getHamid());
            List<Tbj29LoginUserVO> tbl29list = dao.selectVO(tbj29cond);
            if (tbl29list.size() > 0) {
                Tbj29LoginUserVO tbj29deletevo = new Tbj29LoginUserVO();
                tbj29deletevo.setHAMID(startupcond.getHamid());
                dao.deleteVO(tbj29deletevo);
            }
            if (result.getUserList() != null && result.getUserList().size() > 0) {
                Tbj29LoginUserVO tbj29insertvo = new Tbj29LoginUserVO();
                tbj29insertvo.setHAMID(startupcond.getHamid());
                tbj29insertvo.setAFFILIATION(startupcond.getAffiliation());
                tbj29insertvo.setCRTNM(usrNm);
                tbj29insertvo.setCRTAPL(startupcond.getUpdapl());
                tbj29insertvo.setCRTID(startupcond.getHamid());
                tbj29insertvo.setUPDNM(usrNm);
                tbj29insertvo.setUPDAPL(startupcond.getUpdapl());
                tbj29insertvo.setUPDID(startupcond.getHamid());
                dao.insertVO(tbj29insertvo);
            }
        }

        // システム使用状況取得
        Mbj01SysStsDAO sysdao = Mbj01SysStsDAOFactory.createMbj01SysStsDAO();
        result.setSysStsList(sysdao.selectVO(new Mbj01SysStsCondition()));

        // 新HAM向けVIEW(個人情報)取得
        Vbj01AccUserDAO vbj01dao = Vbj01AccUserDAOFactory.createVbj01AccUserDAO();
        Vbj01AccUserCondition vbj01cond = new Vbj01AccUserCondition();
        vbj01cond.setEsqid(startupcond.getHamid());
        vbj01cond.setSikognzuntcd(startupcond.getSikcd());
        result.setAccUserList(vbj01dao.selectVO(vbj01cond));

        // 管理テーブル取得
        Tbj35KnrDAO tbj35dao = Tbj35KnrDAOFactory.createTbj35KnrDAO();
        Tbj35KnrCondition tbj35cond = new Tbj35KnrCondition();
        result.setKnrList(tbj35dao.selectVO(tbj35cond));

        // 業務会計の営業日取得
        String eigyobi = null;
        for (Tbj35KnrVO knrVo : result.getKnrList()) {
            if (knrVo.getSYSTEMNO().equals("02")) {
                eigyobi = knrVo.getEIGYOBI();
                break;
            }
        }

        // 経理組織展開テーブル取得
        if (eigyobi != null) {
            RepaVbjaMeu07SikKrSprdDAO sikKrSprdDao = RepaVbjaMeu07SikKrSprdDAOFactory.createRepaVbjaMeu07SikKrSprdDAO();
            RepaVbjaMeu07SikKrSprdVO sikKrSprdVo = new RepaVbjaMeu07SikKrSprdVO();
            sikKrSprdVo.setSIKCD(startupcond.getSikcd());
            sikKrSprdVo.setSTARTYMD(eigyobi);
            sikKrSprdVo.setENDYMD(eigyobi);
            result.setSikKrSprd(sikKrSprdDao.selectVoByDate(sikKrSprdVo));
        }

        return result;
    }

}
