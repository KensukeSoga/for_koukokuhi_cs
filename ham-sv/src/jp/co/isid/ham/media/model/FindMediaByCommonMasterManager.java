package jp.co.isid.ham.media.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj36MediaPatternItemCondition;
import jp.co.isid.ham.common.model.Mbj36MediaPatternItemDAO;
import jp.co.isid.ham.common.model.Mbj36MediaPatternItemDAOFactory;
import jp.co.isid.ham.common.model.Mbj36MediaPatternItemVO;
import jp.co.isid.ham.model.base.HAMException;

public class FindMediaByCommonMasterManager {

    /** シングルトンインスタンス */
    private static FindMediaByCommonMasterManager _manager = new  FindMediaByCommonMasterManager();

    /** インスタンス化禁止 */
    private FindMediaByCommonMasterManager() {
    }

    /** インスタンス取得 */
    public static FindMediaByCommonMasterManager getInstance() {
        return _manager;
    }

    /**
     * 検索を実行
     * @param cond 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    public FindMediaByCommonMasterResult findMediaByCommonMaster(FindMediaByCommonMasterCondition cond) throws HAMException {

        FindMediaByCommonMasterResult result = new FindMediaByCommonMasterResult();

        //trueの時はパターンから検索実行
        if (cond.getSearchFlg()) {

            //******************************************************
            //媒体パターン情報を取得
            //******************************************************
            Mbj36MediaPatternItemDAO mpdao = Mbj36MediaPatternItemDAOFactory.createMbj36MediaPatternItemDAO();
            Mbj36MediaPatternItemCondition mpcond = new Mbj36MediaPatternItemCondition();
            mpcond.setBaitaipatnno(cond.getPatternNo());
            List<Mbj36MediaPatternItemVO> mpVO = mpdao.selectVO(mpcond);

            if (mpVO.size() == 0) {
                return result;
            }

            //検索対象の文字列を作成
            StringBuffer mediaCd = new StringBuffer();
            int index = 0;
            for (Mbj36MediaPatternItemVO getmpVO: mpVO) {
                if (index != 0) {
                    mediaCd.append(",");
                }
                mediaCd.append("'");
                mediaCd.append(getmpVO.getNPCD());
                mediaCd.append("'");
                index++;
            }

            // ******************************************************
            // パターン検索実行の取得
            // ******************************************************
            FindMediaByCommonMasterDAO mediadao = FindMediaByCommonMasterDAOFactory.createFindAuthorityAccountBookDAO();
            cond.setMediaCd(mediaCd.toString());
            result.setMediaByCommonMasterVO(mediadao.FindMediaByMediaCd(cond));

        } else {

            // ******************************************************
            // 文字列検索実行の取得
            // ******************************************************
            FindMediaByCommonMasterDAO mediadao = FindMediaByCommonMasterDAOFactory.createFindAuthorityAccountBookDAO();
            result.setMediaByCommonMasterVO(mediadao.FindMediaByMediaNm(cond));
        }

        return result;
    }

}
