package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj37DisplayControlVO;
import jp.co.isid.ham.common.model.Mbj50RdStationVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
* <P>
* ラジオ局選択画面情報結果セット
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/10/31 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdStationSelectResult extends AbstractServiceResult {

    /** 画面表示列情報 */
    private List<Mbj37DisplayControlVO> _disp = null;
    /** ラジオ局マスタ情報 */
    private List<Mbj50RdStationVO> _rdStation = null;

    /**
     * 画面表示列情報を取得する
     * @return List<Mbj37DisplayControlVO> 画面表示列情報
     */
    public List<Mbj37DisplayControlVO> getMbj37DisplayControl() {
        return _disp;
    }

    /**
     * 画面表示列情報を設定する
     * @param vo List<Mbj37DisplayControlVO> 画面表示列情報
     */
    public void setMbj37DisplayControl(List<Mbj37DisplayControlVO> vo) {
        _disp = vo;
    }

    /**
     * ラジオ局マスタ情報を取得する
     * @return List<Mbj50RdStationVO> ラジオ局マスタ
     */
    public List<Mbj50RdStationVO> getMbj50RdStation() {
        return _rdStation;
    }

    /**
     * ラジオ局マスタ情報を設定する
     * @param vo List<Mbj50RdStationVO> ラジオ局マスタ情報
     */
    public void setMbj50RdStation(List<Mbj50RdStationVO> vo) {
        _rdStation = vo;
    }

}
