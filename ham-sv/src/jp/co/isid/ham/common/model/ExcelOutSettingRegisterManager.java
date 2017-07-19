package jp.co.isid.ham.common.model;

import java.util.Date;
import java.util.List;

import jp.co.isid.ham.model.base.HAMException;

public class ExcelOutSettingRegisterManager {

    /** シングルトンインスタンス */
    private static ExcelOutSettingRegisterManager _manager = new ExcelOutSettingRegisterManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private ExcelOutSettingRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static ExcelOutSettingRegisterManager getInstance() {
        return _manager;
    }

    /**
     * 帳票出力設定情報を登録します
     *
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public void excelOutSettingRegister(ExcelOutSettingRegisterVO vo)
            throws HAMException {
        exclusionCheck(vo);
        ExcelOutMediaRegisterDAO mediaDAO = ExcelOutSettingRegisterDAOFactory.createExcelOutMediaRegisterDAO();
        ExcelOutCarRegisterDAO carDAO = ExcelOutSettingRegisterDAOFactory.createExcelOutCarRegisterDAO();

        //一度両方のデータを削除する
        mediaDAO.delMediaOutCtrl(vo.getReportCd(), vo.getPhase());
        carDAO.delCarOutCtrl(vo.getReportCd(), vo.getPhase());

        for (Mbj13CarOutCtrlVO carvo : vo.getMbj13CarOutCtrlVO()) {
            carDAO.insCarOutCtrl(carvo);
        }
        for (Mbj14MediaOutCtrlVO mediavo : vo.getMbj14MediaOutCtrlVO()) {
            mediaDAO.insMediaOutCtrl(mediavo);
        }
    }

    /**
     * 排他チェックを行います
     * @throws HAMException
     *
     */
    private  void exclusionCheck(ExcelOutSettingRegisterVO condVO) throws HAMException {

        //再検索をする.
        FindExcelOutSettingCondition cond = new FindExcelOutSettingCondition();
        cond.setPhase(condVO.getPhase());
        cond.setReportcd(condVO.getReportCd());
        // ******************************************************
        // 媒体出力設定の取得
        // ******************************************************
        OutputMediaDAO mediadao = OutputMediaDAOFactory.createOutputMediaDAO();
        List<OutputMediaVO> list = mediadao.findOutputMediaList(cond);

        String dataCnt = Integer.toString(list.size());

        if (!dataCnt.equals(condVO.getDataCnt())) {
            throw new HAMException("登録","BJ-E0005");
        }

        if (list.size() > 0)
        {
            //最新日時を取得.
            OutputMediaVO result = new OutputMediaVO();
            int count = 0;
            for (OutputMediaVO vo : list) {
                if (count == 0) {
                    result = vo;
                    count++;
                    continue;
                }
                if (result.getUPDDATE().before(vo.getUPDDATE())) {
                    result = vo;
                }
                count++;
            }

            Date getDate = new Date(result.getUPDDATE().getTime());

            if (!getDate.equals(condVO.getLatestDate())) {
                throw new HAMException("登録","BJ-E0005");
            }

            if (!result.getUPDID().equals(condVO.getLatestID())) {
                throw new HAMException("登録","BJ-E0005");
            }
        }
    }
}

