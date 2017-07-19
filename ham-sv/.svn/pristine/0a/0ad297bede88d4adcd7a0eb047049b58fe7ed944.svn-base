package jp.co.isid.ham.production.model;

import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;
import jp.co.isid.ham.common.model.Mbj30InputTntVO;
import jp.co.isid.ham.common.model.Tbj11CrCreateDataVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
 * <P>
 * CR制作費　登録実行時の結果クラス
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/30 新HAMチーム)<BR>
 * </P>
 *
 * @author 新HAMチーム
 */
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class RegisterCrCreateDataResult extends AbstractServiceResult {


    /** 入力担当マスタVOリスト */
    private List<Mbj30InputTntVO> _mbj30InputTntVoList = null;

    /** CR制作費管理VOリスト(制作費管理NOのみ設定) */
    private List<Tbj11CrCreateDataVO> _tbj11CrCreateDataVoList = null;

    /**
     * 入力担当マスタVOリストを取得する
     * @return 入力担当マスタVOリスト
     */
    public List<Mbj30InputTntVO> getMbj30InputTntVoList() {
        return _mbj30InputTntVoList;
    }

    /**
     * 入力担当マスタVOリストを設定する
     * @param mbj30InputTntVoList 入力担当マスタVOリスト
     */
    public void setMbj30InputTntVoList(List<Mbj30InputTntVO> mbj30InputTntVoList) {
        this._mbj30InputTntVoList = mbj30InputTntVoList;
    }

    /**
     * CR制作費管理VOリストを取得する
     *
     * @return CR制作費管理VOリスト
     */
    public List<Tbj11CrCreateDataVO> getTbj11CrCreateDataVoList() {
        return _tbj11CrCreateDataVoList;
    }

    /**
     * CR制作費管理VOリストを設定する
     *
     * @param tbj11CrCreateDataVoList CR制作費管理VOリスト
     */
    public void setTbj11CrCreateDataVoList(List<Tbj11CrCreateDataVO> tbj11CrCreateDataVoList) {
        this._tbj11CrCreateDataVoList = tbj11CrCreateDataVoList;
    }
}
