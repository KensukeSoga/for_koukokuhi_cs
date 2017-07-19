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
* ���W�I��AllocationPicture�������ʃZ�b�g
* </P>
* <P>
* <B>�C������</B><BR>
* �E�V�K�쐬(2015/11/20 HLC S.Fujimoto)<BR>
* </P>
* @author S.Fujimoto
*/
@XmlRootElement(namespace = "http://model.media.ham.isid.co.jp/")
@XmlType(namespace = "http://model.media.ham.isid.co.jp/")
public class FindRdAllocationPictureResult extends AbstractServiceResult {

    /** �f�ޏ�� */
    private List<FindRdAllocationPictureMaterialVO> _rdAPMaterial = null;
    /** ���W�I�ԑg��� */
    private List<Tbj37RdProgramVO> _rdAPProgram = null;
    /** ���W�I�ԑg�f�ޏ�� */
    private List<FindRdAllocationPictureProgramMaterialVO> _rdAPProgramMaterial = null;
    /** ���W�I�ԑg�l�b�g�Ǐ�� */
    private List<Tbj39RdProgramStationVO> _rdAPStation = null;
    /** ���W�I�ǃ}�X�^ */
    private List<Mbj50RdStationVO> _rdStation = null;
    /** �Ԏ�}�X�^ */
    private List<Mbj05CarVO> _car = null;

    /**
     * �f�ޏ����擾����
     * @return List<FindRdAllocationPictureMaterialVO> �f�ޏ��
     */
    public List<FindRdAllocationPictureMaterialVO> getRdAPMaterial() {
        return _rdAPMaterial;
    }

    /**
     * �f�ޏ���ݒ肷��
     * @param vo List<FindRdAllocationPictureMaterialVO> �f�ޏ��
     */
    public void setRdAPMaterial(List<FindRdAllocationPictureMaterialVO> vo) {
        _rdAPMaterial = vo;
    }

    /**
     * ���W�I�ԑg�����擾����
     * @return List<Tbj37RdProgramVO> ���W�I�ԑg���
     */
    public List<Tbj37RdProgramVO> getRdAPProgram() {
        return _rdAPProgram;
    }

    /**
     * ���W�I�ԑg����ݒ肷��
     * @param vo List<Tbj37RdProgramVO> ���W�I�ԑg���
     */
    public void setRdAPProgram(List<Tbj37RdProgramVO> vo) {
        _rdAPProgram = vo;
    }

    /**
     * ���W�I�ԑg�f�ޏ����擾����
     * @return List<FindRdAllocationPictureProgramMaterialVO> ���W�I�ԑg�f�ޏ��
     */
    public List<FindRdAllocationPictureProgramMaterialVO> getRdAPPogramMaterial() {
        return _rdAPProgramMaterial;
    }

    /**
     * ���W�I�ԑg�f�ޏ���ݒ肷��
     * @param vo List<FindRdAllocationPictureProgramMaterialVO> ���W�I�ԑg�f�ޏ��
     */
    public void setRdAPPogramMaterial(List<FindRdAllocationPictureProgramMaterialVO> vo) {
        _rdAPProgramMaterial = vo;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǐ����擾����
     * @return List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǐ��
     */
    public List<Tbj39RdProgramStationVO> getRdAPStation() {
        return _rdAPStation;
    }

    /**
     * ���W�I�ԑg�l�b�g�Ǐ���ݒ肷��
     * @param vo List<Tbj39RdProgramStationVO> ���W�I�ԑg�l�b�g�Ǐ��
     */
    public void setRdAPStation(List<Tbj39RdProgramStationVO> vo) {
        _rdAPStation = vo;
    }

    /**
     * ���W�I�ǃ}�X�^���擾����
     * @return List<Mbj50rdStationVO> ���W�I�ǃ}�X�^
     */
    public List<Mbj50RdStationVO> getRdStation() {
        return _rdStation;
    }

    /**
     * ���W�I�ǃ}�X�^��ݒ肷��
     * @param vo List<Mbj50rdStationVO> ���W�I�ǃ}�X�^
     */
    public void setRdStation(List<Mbj50RdStationVO> vo) {
        _rdStation = vo;
    }

    /**
     * �Ԏ�}�X�^���擾����
     * @return List<Mbj05CarVO> �Ԏ�}�X�^
     */
    public List<Mbj05CarVO> getCar() {
        return _car;
    }

    /**
     * �Ԏ�}�X�^��ݒ肷��
     * @param vo List<Mbj05CarVO> �Ԏ�}�X�^
     */
    public void setCar(List<Mbj05CarVO> vo) {
        _car = vo;
    }

}
