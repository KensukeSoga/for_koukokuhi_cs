package jp.co.isid.ham.media.model;

import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj05CarVO;
import jp.co.isid.ham.common.model.Mbj50RdStationVO;
import jp.co.isid.ham.common.model.Tbj37RdProgramVO;
import jp.co.isid.ham.common.model.Tbj39RdProgramStationVO;
import jp.co.isid.ham.model.AbstractServiceResult;

/**
*
* <P>
* ラジオ版AllocationPicture検索結果セット
* </P>
* <P>
* <B>修正履歴</B><BR>
* ・新規作成(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdAllocationPictureResult extends AbstractServiceResult {

    /** 素材情報 */
    private List<FindRdAllocationPictureMaterialVO> _rdAPMaterial = null;
    /** ラジオ番組情報 */
    private List<Tbj37RdProgramVO> _rdAPProgram = null;
    /** ラジオ番組素材情報 */
    private List<FindRdAllocationPictureProgramMaterialVO> _rdAPProgramMaterial = null;
    /** ラジオ番組ネット局情報 */
    private List<Tbj39RdProgramStationVO> _rdAPStation = null;
    /** ラジオ局マスタ */
    private List<Mbj50RdStationVO> _rdStation = null;
    /** 車種マスタ */
    private List<Mbj05CarVO> _car = null;

    /**
     * 素材情報を取得する
     * @return List<FindRdAllocationPictureMaterialVO> 素材情報
     */
    public List<FindRdAllocationPictureMaterialVO> getRdAPMaterial() {
        return _rdAPMaterial;
    }

    /**
     * 素材情報を設定する
     * @param vo List<FindRdAllocationPictureMaterialVO> 素材情報
     */
    public void setRdAPMaterial(List<FindRdAllocationPictureMaterialVO> vo) {
        _rdAPMaterial = vo;
    }

    /**
     * ラジオ番組情報を取得する
     * @return List<Tbj37RdProgramVO> ラジオ番組情報
     */
    public List<Tbj37RdProgramVO> getRdAPProgram() {
        return _rdAPProgram;
    }

    /**
     * ラジオ番組情報を設定する
     * @param vo List<Tbj37RdProgramVO> ラジオ番組情報
     */
    public void setRdAPProgram(List<Tbj37RdProgramVO> vo) {
        _rdAPProgram = vo;
    }

    /**
     * ラジオ番組素材情報を取得する
     * @return List<FindRdAllocationPictureProgramMaterialVO> ラジオ番組素材情報
     */
    public List<FindRdAllocationPictureProgramMaterialVO> getRdAPPogramMaterial() {
        return _rdAPProgramMaterial;
    }

    /**
     * ラジオ番組素材情報を設定する
     * @param vo List<FindRdAllocationPictureProgramMaterialVO> ラジオ番組素材情報
     */
    public void setRdAPPogramMaterial(List<FindRdAllocationPictureProgramMaterialVO> vo) {
        _rdAPProgramMaterial = vo;
    }

    /**
     * ラジオ番組ネット局情報を取得する
     * @return List<Tbj39RdProgramStationVO> ラジオ番組ネット局情報
     */
    public List<Tbj39RdProgramStationVO> getRdAPStation() {
        return _rdAPStation;
    }

    /**
     * ラジオ番組ネット局情報を設定する
     * @param vo List<Tbj39RdProgramStationVO> ラジオ番組ネット局情報
     */
    public void setRdAPStation(List<Tbj39RdProgramStationVO> vo) {
        _rdAPStation = vo;
    }

    /**
     * ラジオ局マスタを取得する
     * @return List<Mbj50rdStationVO> ラジオ局マスタ
     */
    public List<Mbj50RdStationVO> getRdStation() {
        return _rdStation;
    }

    /**
     * ラジオ局マスタを設定する
     * @param vo List<Mbj50rdStationVO> ラジオ局マスタ
     */
    public void setRdStation(List<Mbj50RdStationVO> vo) {
        _rdStation = vo;
    }

    /**
     * 車種マスタを取得する
     * @return List<Mbj05CarVO> 車種マスタ
     */
    public List<Mbj05CarVO> getCar() {
        return _car;
    }

    /**
     * 車種マスタを設定する
     * @param vo List<Mbj05CarVO> 車種マスタ
     */
    public void setCar(List<Mbj05CarVO> vo) {
        _car = vo;
    }

}
