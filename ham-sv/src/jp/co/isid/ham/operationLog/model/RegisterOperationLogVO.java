package jp.co.isid.ham.operationLog.model;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj28WorkLogVO;

/**
 * <P>
 * 稼働ログ　登録実行時の登録データ保持クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2013/06/06 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.operationLog.ham.isid.co.jp/")
@XmlType(namespace = "http://model.operationLog.ham.isid.co.jp/")
public class RegisterOperationLogVO implements Serializable {

    /**
     * serialVersionUID
     */
    private static final long serialVersionUID = 1L;

    /** 稼働ログVO */
    private Tbj28WorkLogVO _workLogVo = null;

    /**
     * 稼働ログVOを取得する
     *
     * @return 稼働ログVO
     */
    public Tbj28WorkLogVO getWorkLogVo() {
        return _workLogVo;
    }

    /**
     * 稼働ログVOを設定する
     * @param workLogVo 稼働ログVO
     */
    public void setWorkLogVo(Tbj28WorkLogVO workLogVo) {
        this._workLogVo = workLogVo;
    }



}
