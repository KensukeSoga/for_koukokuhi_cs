package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;

/**
 * <P>
 * 一覧表示パターンを管理する
 * ※列設定画面ができるまでの仮の実装です後々削除される可能性が大の為使用しないでください
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/11 K.Fukuda)<BR>
 * </P>
 * @author K.Fukuda
 */
public class Tbj30DisplayPatternManager {

    /** シングルトンインスタンス */
    private static Tbj30DisplayPatternManager _manager = new Tbj30DisplayPatternManager();

    /**
     * シングルトンの為、インスタンス化を禁止します
     */
    private Tbj30DisplayPatternManager() {
    }

    /**
     * インスタンスを返します
     * @return インスタンス
     */
    public static Tbj30DisplayPatternManager getInstance() {
        return _manager;
    }

    /**
     * 画面項目表示列制御マスタを取得します
     * @param cond 条件
     * @return 画面項目表示列制御マスタ
     * @throws HAMException
     */
    public Tbj30DisplayPatternResult findTbj30DisplayPattern(Tbj30DisplayPatternCondition cond) throws HAMException {

        // 検索結果
        Tbj30DisplayPatternResult result = new Tbj30DisplayPatternResult();

        Tbj30DisplayPatternDAO dpDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        Tbj30DisplayPatternVO condVo = new Tbj30DisplayPatternVO();
        condVo.setFORMID(cond.getHamid());
        condVo.setFORMID(cond.getFormid());
        condVo.setFORMID(cond.getViewid());
        Tbj30DisplayPatternVO list = dpDao.loadVO(condVo);

        result.setDisplayControlList(list);

        return result;
    }

    public void registerTbj30DisplayPattern(List<Tbj30DisplayPatternVO> voList) throws HAMException {

        Tbj30DisplayPatternDAO dpDao = Tbj30DisplayPatternDAOFactory.createTbj30DisplayPatternDAO();
        for (int i = 0; i < voList.size(); i++) {
            try {
                dpDao.deleteVO(voList.get(i));
            } catch(UserException e) {
                //とりあえず無視
            }
            dpDao.insertVO(voList.get(i));
        }
    }

}
