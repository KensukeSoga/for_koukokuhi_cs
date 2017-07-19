package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj37DisplayControlCondition;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAO;
import jp.co.isid.ham.common.model.Mbj37DisplayControlDAOFactory;
import jp.co.isid.ham.common.model.Mbj50RdStationCondition;
import jp.co.isid.ham.common.model.Mbj50RdStationDAO;
import jp.co.isid.ham.common.model.Mbj50RdStationDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternCondition;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAO;
import jp.co.isid.ham.common.model.Tbj30DisplayPatternDAOFactory;
import jp.co.isid.ham.common.model.Tbj37RdProgramCondition;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialCondition;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAO;
import jp.co.isid.ham.common.model.Tbj38RdProgramMaterialDAOFactory;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationCondition;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationDAO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * ラジオ番組一覧表示情報を管理する
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindRdProgramManager {

    /** シングルトンインスタンス */
    private static FindRdProgramManager _manager = new FindRdProgramManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindRdProgramManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static FindRdProgramManager getInstance() {
        return _manager;
    }

    /**
     * ラジオ番組一覧情報を検索します
     * @param cond 検索条件
     * @return ラジオ番組一覧情報
     * @throws HAMException 処理中にエラーが発生した場合
     */
    public FindRdProgramResult findRdProgram(FindRdProgramCondition cond) throws HAMException {

        //検索結果
        FindRdProgramResult result = new FindRdProgramResult();

        //機能制御情報取得
        FunctionControlInfoManager funcManager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funcCond = new FunctionControlInfoCondition();
        funcCond.setFormid(cond.getFormID());
        funcCond.setFunctype(cond.getFunctionType());
        funcCond.setHamid(cond.getHamid());
        funcCond.setUsertype(cond.getUserType());
        funcCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfo(funcManager.getFunctionControlInfo(funcCond).getFunctionControlInfo());

        //セキュリティ情報取得
        SecurityInfoManager secManager = SecurityInfoManager.getInstance();
        SecurityInfoCondition secCond = new SecurityInfoCondition();
        secCond.setHamid(cond.getHamid());
        secCond.setKksikognzuntcd(cond.getKksikognzuntcd());
        secCond.setSecuritycd(cond.getSecuritycd());
        secCond.setUsertype(cond.getUserType());
        result.setSecurityInfo(secManager.getSecurityInfo(secCond).getSecurityInfo());

        //画面項目表示列制御マスタ取得
        Mbj37DisplayControlDAO mbj37dao = Mbj37DisplayControlDAOFactory.createMbj37DisplayControlDAO();
        Mbj37DisplayControlCondition mbj37cond = new Mbj37DisplayControlCondition();
        mbj37cond.setFormid(cond.getFormID());
        result.setSpdControl(mbj37dao.selectVO(mbj37cond));

        //一覧表示パターン取得
        Tbj30DisplayPatternDAO tbj30dao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternCondition tbj30cond = new Tbj30DisplayPatternCondition();
        tbj30cond.setHamid(cond.getHamid());
        tbj30cond.setFormid(cond.getFormID());
        tbj30cond.setViewid(cond.getViewID());
        result.setDispPattern(tbj30dao.selectVO(tbj30cond));

        //コードマスタ取得
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < cond.getCodeList().size(); i++) {
            sb.append(" ");
            sb.append(cond.getCodeList().get(i));
            sb.append(",");
        }

        Mbj12CodeDAO mbj12dao = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition mbj12Cond = new Mbj12CodeCondition();
        mbj12Cond.setCodetype(sb.substring(0, sb.toString().length() - 1).trim());
        result.setCode(mbj12dao.FindManyCd(mbj12Cond));

        //ラジオ局マスタ取得
        Mbj50RdStationDAO mbj50dao = Mbj50RdStationDAOFactory.createMbj50RdStationDAO();
        Mbj50RdStationCondition mbj50cond = new Mbj50RdStationCondition();
        result.setRdStation(mbj50dao.selectVO(mbj50cond));

        //ラジオ番組情報取得
        FindRdProgramListDAO rdPgmListdao = FindRdProgramRegisterDAOFactory.createFindRdProgramListDAOFactory();
        Tbj37RdProgramCondition tbj37cond = new Tbj37RdProgramCondition();
        result.setRdProgram(rdPgmListdao.findRdProgramInfo(tbj37cond));

        //ラジオ番組素材情報取得
        Tbj38RdProgramMaterialDAO tbj38dao = Tbj38RdProgramMaterialDAOFactory.createTbj38RdProgramMaterialDAO();
        Tbj38RdProgramMaterialCondition tbj38cond = new Tbj38RdProgramMaterialCondition();
        result.setRdProgramMaterial(tbj38dao.selectVO(tbj38cond));

        //ラジオ番組ネット局情報取得
        Tbj39RdProgramStationDAO tbj39dao = Tbj39RdProgramStationDAOFactory.createTbj39RdProgramStationDAO();
        Tbj39RdProgramStationCondition tbj39cond = new Tbj39RdProgramStationCondition();
        result.setRdProgramStation(tbj39dao.selectVO(tbj39cond));

        return result;
    }

}
