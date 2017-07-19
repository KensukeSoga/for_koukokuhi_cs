package jp.co.isid.ham.media.model;

import jp.co.isid.ham.common.model.Tbj02EigyoDaichoVO;
import jp.co.isid.ham.model.base.HAMException;

public class UpdABOrderOutRegisterManager {

    /** シングルトンインスタンス */
    private static UpdABOrderOutRegisterManager _manager = new UpdABOrderOutRegisterManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private UpdABOrderOutRegisterManager() {
    }

    /**
     * インスタンスを返します
     *
     * @return インスタンス
     */
    public static UpdABOrderOutRegisterManager getInstance() {
        return _manager;
    }

    /**
     * 営業作業台帳を更新します
     * @throws HAMException
     * @throws HAMException
     *             処理中にエラーが発生した場合
     */
    public void UpdAccountBookOutFlg(UpdABOrderOutRegisterVO vo) throws HAMException {

        UpdABOrderOutRegisterDAO dao = UpdABOrderOutRegisterDAOFactory.createUpdABOrderOutRegisterDAO();

        //更新
        if (vo.getUpdVo() != null && !vo.getUpdVo().equals("")) {

            for (Tbj02EigyoDaichoVO updvo : vo.getUpdVo()) {
                dao.updAccounBook(updvo);
            }
        }
    }

}
