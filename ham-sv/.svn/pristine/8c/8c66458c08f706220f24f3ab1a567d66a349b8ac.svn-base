package jp.co.isid.ham.production.model;

import java.util.List;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj17ContentVO;

/**
 * <P>
 * 素材登録　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/05 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
public class RegisterMaterialContentVO extends Tbj18SozaiKanriDataVO {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /**
     * コンテンツリスト変数
     */
    private List<Tbj17ContentVO> _dtlList = null;

    /**
     * 新規インスタンスを生成する
     *
     * @return 新規インスタンス
     */
    public Object newInstance() {
        return new RegisterMaterialContentVO();
    }

    /**
     * 素材に紐付くコンテンツリストを設定します
     * @param list
     */
    public void setTbj17ContentVOList(List<Tbj17ContentVO> list) {
        _dtlList = list;
    }


    /**
     * 素材に紐付くコンテンツリストを取得します
     * @return
     */
    public List<Tbj17ContentVO> getTbj17ContentVOList() {
        return _dtlList;
    }

}
