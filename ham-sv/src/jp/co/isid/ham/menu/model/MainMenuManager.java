package jp.co.isid.ham.menu.model;



import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.common.model.Mbj31InformationCondition;
import jp.co.isid.ham.common.model.Mbj31InformationDAO;
import jp.co.isid.ham.common.model.Mbj31InformationDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.SecurityInfoVO;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * メインメニュー表示情報を管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/7 T.Fujiyoshi)<BR>
 * </P>
 * @author T.Fujiyoshi
 */
public class MainMenuManager {

    /** シングルトンインスタンス */
    private static MainMenuManager _manager = new MainMenuManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private MainMenuManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static MainMenuManager getInstance() {
        return _manager;
    }

    /**
     * メインメニューの表示情報を取得します
     * @param cond 条件
     * @return メインメニューの表示情報
     * @throws HAMException
     */
    public FindMainMenuResult findMainMenu(FindMainMenuCondition cond) throws HAMException {

        // 検索結果
        FindMainMenuResult result = new FindMainMenuResult();

        // 機能制御Infoの取得
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamID());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // 画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO dcdao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition dccond = new Mbj37DisplayControlCondition();
        dccond.setFormid(cond.getFormID());
        result.setDisplayControl(dcdao.selectVO(dccond));

        // インフォメーションマスタ取得
        Mbj31InformationDAO infodao = Mbj31InformationDAOFactory.createMbj31InformationDAO();
        Mbj31InformationCondition mbj31cond = new Mbj31InformationCondition();
        mbj31cond.setDispsts("1");
        result.setInfo(infodao.selectVO(mbj31cond));

        // ログインユーザー取得
        LoginDAO logindao = FindMainMenuDAOFactory.createLoginDAO();
        result.setLogin(logindao.selectVO());

        // CR制作費管理(受注No未入力)取得(入力担当者=姓名)
        UserCrCreateDataDAO userdao = FindMainMenuDAOFactory.createUserCrCreateDataDAO();
        cond.setInputIntNm(cond.getLastName() + cond.getFirstName());
        result.setNoInputOrderNo(userdao.selectNoInputOrderNo(cond));

        // 電通車種コード[全て](アラート表示制御)取得
        Mbj12CodeDAO codedao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codecond = new Mbj12CodeCondition();
        codecond.setCodetype("25");
        List<Mbj12CodeVO> codeVoList = codedao.selectVO(codecond);
        if (codeVoList != null && codeVoList.size() > 0) {
            cond.setDCarCdAll(codeVoList.get(0).getKEYCODE());
        }
        else {
            cond.setDCarCdAll(" ");
        }


        // ******************************************************
        // (CR制作費の)セキュリティ情報取得
        // ******************************************************
        SecurityInfoManager secManager = SecurityInfoManager.getInstance();
        SecurityInfoCondition secCond = new SecurityInfoCondition();
        List<SecurityInfoVO> secVolist = new ArrayList<SecurityInfoVO>();
        secCond.setHamid(cond.getHamID());
        secCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        secCond.setSecuritycd("S000000104");
        secCond.setUsertype(cond.getUsertype());
        secVolist = secManager.getSecurityInfo(secCond).getSecurityInfo();
        for (SecurityInfoVO securityInfoVO : secVolist) {
            if (securityInfoVO.getCHECK().equals("1")) {
                // 確認機能が有効ならCR制作費管理(変更データ)取得

                //AM局として操作しているかを判定してCondtionに結果をセット
                codecond = new Mbj12CodeCondition();
                codecond.setCodetype("24");
                List<Mbj12CodeVO> amKykSikCdList = codedao.selectVO(codecond);
                boolean isAm = false;
                //TODO:件数も少ないのでとりあえずLoopさせて判定
                for (Mbj12CodeVO mbj12CodeVO : amKykSikCdList) {
                    if (mbj12CodeVO.getYOBI1().equals(cond.getKksikognzuntcd()))
                    {
                        if (mbj12CodeVO.getYOBI2().equals("1")) {
                            isAm = true;
                        }
                        break;
                    }
                }
                cond.setIsAmKyk(isAm);

                // CR制作費管理(変更データ)取得
                result.setUpdatedCr(userdao.selectUpdatedCr(cond));
                break;
            }
        }
//
//        // CR制作費管理(変更データ)取得
//        result.setUpdatedCr(userdao.selectUpdatedCr(cond));

        return result;
    }

}
