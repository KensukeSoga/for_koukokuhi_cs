package jp.co.isid.ham.billing.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import jp.co.isid.ham.common.model.FindExcelOutSettingCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoCondition;
import jp.co.isid.ham.common.model.FunctionControlInfoManager;
import jp.co.isid.ham.common.model.Mbj12CodeCondition;
import jp.co.isid.ham.common.model.Mbj12CodeDAO;
import jp.co.isid.ham.common.model.Mbj12CodeDAOFactory;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAO;
import jp.co.isid.ham.common.model.Mbj26BillGroupDAOFactory;
import jp.co.isid.ham.common.model.OutputCarDAO;
import jp.co.isid.ham.common.model.OutputCarDAOFactory;
import jp.co.isid.ham.common.model.OutputMediaDAO;
import jp.co.isid.ham.common.model.OutputMediaDAOFactory;
import jp.co.isid.ham.common.model.SecurityInfoCondition;
import jp.co.isid.ham.common.model.SecurityInfoManager;
import jp.co.isid.ham.common.model.Tbj14FeeKanriCondition;
import jp.co.isid.ham.common.model.Tbj14FeeKanriDAO;
import jp.co.isid.ham.common.model.Tbj14FeeKanriDAOFactory;
import jp.co.isid.ham.common.model.Tbj34CutManagementCondition;
import jp.co.isid.ham.common.model.Tbj34CutManagementDAO;
import jp.co.isid.ham.common.model.Tbj34CutManagementDAOFactory;
import jp.co.isid.ham.model.base.HAMException;

/**
 * <P>
 * コスト管理表出力データを取得
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/4/2 HLC H.Watabe)<BR>
 * </P>
 * @author HLC H.Watabe
 */
public class FindCostManagementReportManager {

    /** シングルトンインスタンス */
    private static FindCostManagementReportManager _manager = new FindCostManagementReportManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private FindCostManagementReportManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static FindCostManagementReportManager getInstance() {
        return _manager;
    }

    /**
     * コスト管理表出力データ検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindCostManagementReportResult ｆindCostManagementReport(FindCostManagementReportCondition cond) throws HAMException {

        FindCostManagementReportResult result = new FindCostManagementReportResult();

        //媒体コスト取得
        FindMediaCostDAO mediaDAO = FindCostManagementReportDAOFactory.createFindMediaCostDAO();
        List<FindMediaCostVO> mediaCostList = mediaDAO.findMediaCost(cond);
        result.setFindMediaCostVO(mediaCostList);

        //制作費コスト取得
        FindCreateCostDAO crDAO = FindCostManagementReportDAOFactory.createFindCreateCostDAO();
        List<FindCreateCostVO> createCostList = crDAO.findCreateCost(cond);
        result.setFindCreateCostVO(createCostList);

        List<FindCreateUptakeCostVO> createUpCostList = new ArrayList<FindCreateUptakeCostVO>();
        if (cond.getPhase() > 85) {
            //制作費取込コスト取得
            FindCreateUptakeCostDAO crUpDAO = FindCostManagementReportDAOFactory.createFindCreateUptakeCostDAO();
            createUpCostList = crUpDAO.findCreateUptakeCost(cond);
            result.setFindCreateUptakeCostVO(createUpCostList);
        }

        //----------出力媒体、車種の取得-----------//
        OutputMediaDAO outMediaDAO = OutputMediaDAOFactory.createOutputMediaDAO();
        OutputCarDAO outCarDAO = OutputCarDAOFactory.createOutputCarDAO();
        FindExcelOutSettingCondition settingCond = new FindExcelOutSettingCondition();
        settingCond.setPhase(BigDecimal.valueOf(cond.getPhase()));
        settingCond.setReportcd("R05");
        //出力車種、出力媒体を取得
        //\0の車種、媒体も表示する場合は全部取得
        if (!cond.getFeeGetFlg()) {
            result.setOutputCarVO(outCarDAO.findOutputCarList(settingCond));
            result.setOutputMediaVO(outMediaDAO.findOutputMediaList(settingCond));
        } else {
        //\0の車種、媒体を表示しない時

            //媒体、制作費、制作費取込から取得した車種や媒体を取得
            List<String> carList = new ArrayList<String>();
            List<String> mediaList = new ArrayList<String>();

            //媒体コストからぐるぐる探す
            for (FindMediaCostVO mediaVO : mediaCostList) {
                //リストに見つからなければ対象の車種を追加
                if (carList.indexOf(mediaVO.getDCARCD()) == -1) {
                    carList.add(mediaVO.getDCARCD());
                }
                //リストに見つからなければ対象の媒体を追加
                if (mediaList.indexOf(mediaVO.getMEDIACD()) == -1) {
                    mediaList.add(mediaVO.getMEDIACD());
                }
            }
            //制作費コストからぐるぐる探す
            for (FindCreateCostVO createVO : createCostList) {
                //リストに見つからなければ対象の車種を追加
                if (carList.indexOf(createVO.getDCARCD()) == -1) {
                    carList.add(createVO.getDCARCD());
                }
            }
            if (cond.getPhase() > 85) {
                //制作費コストからぐるぐる探す
                for (FindCreateUptakeCostVO createUpVO : createUpCostList) {
                    //リストに見つからなければ対象の車種を追加
                    if (carList.indexOf(createUpVO.getDCARCD()) == -1) {
                        carList.add(createUpVO.getDCARCD());
                    }
                }
            }

            StringBuffer searchCar = new StringBuffer();
            StringBuffer searchMedia = new StringBuffer();
            int index = 0;
            for (String dCarCd : carList) {
                if (index != 0) {
                    searchCar.append(",");
                }
                searchCar.append("'");
                searchCar.append(dCarCd);
                searchCar.append("'");
                index++;
            }
            index = 0;
            for (String mediaCd : mediaList) {
                if (index != 0) {
                    searchMedia.append(",");
                }
                searchMedia.append("'");
                searchMedia.append(mediaCd);
                searchMedia.append("'");
                index++;
            }

            if (searchCar.length() != 0) {
                result.setOutputCarVO(outCarDAO.findOutputReportCarList(settingCond, searchCar.toString()));
            }
            if (searchMedia.length() != 0) {
                result.setOutputMediaVO(outMediaDAO.findOutputReportMediaList(settingCond, searchMedia.toString()));
            }
        }
        //----------出力媒体、車種の取得-----------//

        //----------請求先グループの取得-----------//
        Mbj26BillGroupDAO groupDAO = Mbj26BillGroupDAOFactory.createMbj26BillGroupDAO();
        StringBuffer searchGroup = new StringBuffer();
        List<BigDecimal> groupList = new ArrayList<BigDecimal>();
        //制作費コストからぐるぐる探す
        for (FindCreateUptakeCostVO createUpVO : createUpCostList) {
            //リストに見つからなければ対象の車種を追加
            if (groupList.indexOf(createUpVO.getGROUPCD()) == -1) {
                groupList.add(createUpVO.getGROUPCD());
            }
        }
        int index = 0;
        for (BigDecimal groupCd : groupList) {
            if (index != 0) {
                searchGroup.append(",");
            }
            searchGroup.append(groupCd);
            index++;
        }
        if (searchGroup.length() != 0) {
            result.setMbj26BillGroupVO(groupDAO.selectIN(searchGroup.toString()));
        }

        //----------請求先グループの取得-----------//
        //----------フィー情報の取得-----------//
        Mbj12CodeDAO codeDAO = Mbj12CodeDAOFactory.createMbj12CodeDAO();
        Mbj12CodeCondition codeCond = new Mbj12CodeCondition();
        codeCond.setCodetype("05");
        result.setMbj12CodeVO(codeDAO.selectVO(codeCond));


        //85期以下の期の場合は、フィー管理、削減率管理を参照
        if (cond.getPhase() < 86) {
            Tbj14FeeKanriDAO feeDAO = Tbj14FeeKanriDAOFactory.createTbj14FeeKanriDAO();
            Tbj14FeeKanriCondition feeCond = new Tbj14FeeKanriCondition();
            feeCond.setPhase(BigDecimal.valueOf(cond.getPhase()));
            result.setTbj14FeeKanriVO(feeDAO.findPhaseFee(feeCond,cond.getKikanFrom(),cond.getKikanTo()));

            Tbj34CutManagementDAO cutDAO = Tbj34CutManagementDAOFactory.createTbj34CutManagementDAO();
            Tbj34CutManagementCondition cutCond = new Tbj34CutManagementCondition();
            cutCond.setDatefrom(cond.getKikanFrom());
            cutCond.setDateto(cond.getKikanTo());
            result.setTbj34CutManagementVO(cutDAO.selectVO(cutCond));
        }
        //----------フィー情報の取得-----------//

        return result;
    }


    /**
     * コスト管理表機能制御検索
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindDispCostManagementReportResult ｆindDispCostManagementReport(FindDispCostManagementReportCondition cond) throws HAMException {

        FindDispCostManagementReportResult result = new FindDispCostManagementReportResult();
        // ******************************************************
        // 機能制御Infoの取得
        // ******************************************************
        FunctionControlInfoManager funcmanager = FunctionControlInfoManager.getInstance();
        FunctionControlInfoCondition funccond = new FunctionControlInfoCondition();
        funccond.setFormid(cond.getFormID());
        funccond.setFunctype(cond.getFuncType());
        funccond.setHamid(cond.getHamid());
        funccond.setUsertype(cond.getUsertype());
        funccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        result.setFunctionControlInfoVoList(funcmanager.getFunctionControlInfo(funccond).getFunctionControlInfo());

        // ******************************************************
        // セキュリティInfoの取得
        // ******************************************************
        SecurityInfoManager secmanager = SecurityInfoManager.getInstance();
        SecurityInfoCondition seccond = new SecurityInfoCondition();
        seccond.setHamid(cond.getHamid());
        seccond.setKksikognzuntcd(cond.getKksikognzuntcd());
        seccond.setSecuritycd(cond.getSecuritycd());
        seccond.setUsertype(cond.getUsertype());
        result.setSecurityInfoVoList(secmanager.getSecurityInfo(seccond).getSecurityInfo());

        return result;
    }
}
