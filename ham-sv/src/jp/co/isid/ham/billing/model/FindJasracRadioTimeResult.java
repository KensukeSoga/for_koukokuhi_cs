package jp.co.isid.ham.billing.model;

import java.util.List;

import jp.co.isid.ham.common.model.Mbj12CodeVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * JASRAC申請書(ラジオタイム)結果セット
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/17 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
public class FindJasracRadioTimeResult extends AbstractServiceResult{

    /** コードマスタ */
    List<Mbj12CodeVO> _codeVoList = null;
    /** JASRAC申請書出力情報 */
    List<FindJasracRadioTimeVO> _jasracRTVoList = null;

    /**
     * コードマスタを取得
     * @return List<Mbj12CodeVO> コードマスタ
     */
    public List<Mbj12CodeVO> getCode() {
        return _codeVoList;
    }

    /**
     * コードマスタを設定
     * @param vo List<Mbj12CodeVO> コードマスタ
     */
    public void setCode(List<Mbj12CodeVO> vo) {
        _codeVoList = vo;
    }

    /**
     * JASRAC申請書出力情報を取得
     * @return List<FindJasracRadioTimeVO> JASRAC申請書出力情報
     */
    public List<FindJasracRadioTimeVO> getJasracInfo() {
        return _jasracRTVoList;
    }

    /**
     * JASRAC申請書出力情報を設定
     * @param vo List<FindJasracRadioTimeVO> JASRAC申請書出力情報
     */
    public void setJasracInfo(List<FindJasracRadioTimeVO> vo) {
        _jasracRTVoList = vo;
    }

}
