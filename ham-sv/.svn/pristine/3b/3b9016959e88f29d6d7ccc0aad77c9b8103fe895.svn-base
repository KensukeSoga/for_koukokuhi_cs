package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Tbj20SozaiKanriListCondition;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListDAOFactory;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindSozaiDataByRCodeManager {

    /** シングルトンインスタンス */
    private static FindSozaiDataByRCodeManager _manager = new FindSozaiDataByRCodeManager();

    /** インスタンス化の禁止 */
    private FindSozaiDataByRCodeManager() {
    }

    /**
     * インスタンスを返す
     * @return インスタンス
     */
    public static FindSozaiDataByRCodeManager getInstance() {
        return _manager;
    }

    /**
     * 素材管理リストを検索する
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindSozaiDataByRCodeResult findSozaiDataByRCode(Tbj20SozaiKanriListCondition cond)
            throws HAMException {

        FindSozaiDataByRCodeResult result = new FindSozaiDataByRCodeResult();

        //素材管理リストを検索する
        Tbj20SozaiKanriListDAO sozaidao = Tbj20SozaiKanriListDAOFactory.createTbj20SozaiKanriListDAO();
        List<Tbj20SozaiKanriListVO> sozaivolist = sozaidao.FindSozaiKanriByRCode(cond);
        result.setSozaiKanriList(sozaivolist);

        return result;
    }
}
