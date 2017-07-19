package jp.co.isid.ham.production.model;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj40TempSozaiContentVO;

/**
 * <P>
 * 素材登録
 * 仮素材の本素材登録実行時VO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2015/11/10 HLC S.Fujimoto)<BR>
 * </P>
 * @author S.Fujimoto
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterRealMaterialFromTempMaterialVO implements Serializable {

    private static final long serialVersionUID = 1L;

    /** 仮素材登録更新用VO */
    private List<Tbj36TempSozaiKanriDataVO> _tbj36UpdVo = null;
    /** コンテンツ作成用VO */
    private List<Tbj40TempSozaiContentVO> _tbj40Vo = null;

    /**
     * 仮素材登録更新用VOを取得する
     * @return List<Tbj36TempSozaiKanriDataVO> 仮素材登録更新用VO
     */
    public List<Tbj36TempSozaiKanriDataVO> getTbj36UpdVo() {
        return _tbj36UpdVo;
    }

    /**
     * 仮素材登録更新用VOを設定する
     * @param vo List<Tbj36TempSozaiKanriDataVO> 仮素材登録更新用VO
     */
    public void setTbj36UpdVo(List<Tbj36TempSozaiKanriDataVO> vo) {
        _tbj36UpdVo = vo;
    }

    /**
     * コンテンツ作成用VOを取得する
     * @return List<Tbj17ContentVO> コンテンツ作成用VO
     */
    public List<Tbj40TempSozaiContentVO> getTbj40Vo() {
        return _tbj40Vo;
    }

    /**
     * コンテンツ作成用VOを設定する
     * @param vo List<Tbj17ContentVO> コンテンツ作成用VO
     */
    public void setTbj40Vo(List<Tbj40TempSozaiContentVO> vo) {
        _tbj40Vo = vo;
    }

}